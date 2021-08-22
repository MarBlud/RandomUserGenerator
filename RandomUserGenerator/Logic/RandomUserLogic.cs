using RandomUserGenerator.Helpers;
using RandomUserGenerator.Logic.Interfaces;
using RandomUserGenerator.Models;
using RandomUserGenerator.Repositories.Interfaces;
using System;

namespace RandomUserGenerator.Logic
{
    public class RandomUserLogic : IRandomUserLogic
    {
        private readonly IRandomUserRepository _randomUserRepository;
        private readonly IUserGeneratorHelper _userGeneratorHelper;

        public RandomUserLogic(
            IRandomUserRepository randomUserRepository,
            IUserGeneratorHelper userGeneratorHelper)
        {
            _randomUserRepository = randomUserRepository;
            _userGeneratorHelper = userGeneratorHelper;
        }

        public User GenerateRandomUser()
        {
            var gender = _userGeneratorHelper.GetRandomGender();

            var name = _randomUserRepository.GetRandomName(gender);

            var surname = _randomUserRepository.GetRandomSurname(gender);

            var citizenship = _randomUserRepository.GetRandomCitizenship();

            var birthdate = _userGeneratorHelper.GenerateBirthdate();

            var age = DateTime.Today.Year - birthdate.Year;

            var phoneNumber = _userGeneratorHelper.GeneratePhoneNumber();

            var personalCode = _userGeneratorHelper.GeneratePersonalCode(birthdate, gender);

            return new User
            {
                Gender = gender,
                Name = name,
                Surname = surname,
                Citizenship = citizenship,
                Birthdate = birthdate,
                Age = age,
                PhoneNumber = phoneNumber,
                PersonalCode = personalCode
            };
        }
    }
}
