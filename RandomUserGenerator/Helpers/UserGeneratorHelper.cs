using RandomUserGenerator.Models;
using System;

namespace RandomUserGenerator.Helpers
{
    public class UserGeneratorHelper : IUserGeneratorHelper
    {
        public Gender GetRandomGender()
        {
            var genderValues = Enum.GetValues(typeof(Gender));

            var randomVal = new Random().Next(genderValues.Length);

            return (Gender)genderValues.GetValue(randomVal);
        }

        public DateTime GenerateBirthdate()
        {
            var start = new DateTime(1903, 1, 1);
            var rand = new Random();
            var range = (DateTime.Today - start).Days;

            return start.AddDays(rand.Next(range));
        }

        public string GeneratePhoneNumber()
        {
            var rand = new Random();
            var phoneNumber = "+3706";

            for (int i = 0; i < 7; i++)
            {
                phoneNumber = string.Concat(phoneNumber, rand.Next(10).ToString());
            }

            return phoneNumber;
        }

        public string GeneratePersonalCode(DateTime birthdate, Gender gender)
        {
            //Source: https://en.wikipedia.org/wiki/National_identification_number#Lithuania

            var rand = new Random();

            string personalCode = string.Empty;

            var firstTwoYearDigits = birthdate.Year.ToString().Substring(0, 2);

            int century = int.Parse(firstTwoYearDigits) + 1;

            switch (century)
            {
                case 20:
                    personalCode = gender == Gender.Male ? "3" : "4";
                    break;
                case 21:
                    personalCode = gender == Gender.Male ? "5" : "6";
                    break;
            }

            var birthdateCode =
                birthdate.Year.ToString().Substring(2, 2) +
                birthdate.Month.ToString("00") +
                birthdate.Day.ToString("00");

            personalCode = string.Concat(personalCode, birthdateCode);

            for (int i = 0; i < 3; i++)
            {
                personalCode = string.Concat(personalCode, rand.Next(10).ToString());
            }

            int checksumDigit = PersonalCodeChecksum(personalCode);


            personalCode = string.Concat(personalCode, checksumDigit.ToString());

            return personalCode;
        }

        private int PersonalCodeChecksum(string personalCode)
        {
            //Source: https://en.wikipedia.org/wiki/National_identification_number#Lithuania
            int b = 1, c = 3, d = 0, e = 0;

            for (int i = 0; i < personalCode.Length; i++)
            {
                var digit = int.Parse(personalCode[i].ToString());

                d += digit * b;
                e += digit * c;
                b++;
                if (b == 10) b = 1;
                c++;
                if (c == 10) c = 1;
            }

            d = d % 11;
            e = e % 11;

            if (d < 10)
            {
                return d;
            }
            else if (e < 10)
            {
                return e;
            }
            else
            {
                return 0;
            }
        }
    }
}
