using RandomUserGenerator.Helpers;
using RandomUserGenerator.Models;
using System;
using Xunit;

namespace RandomUserGeneratorTests.PersonalCodeTests
{
    public class PersonalCodeTests
    {
        private readonly UserGeneratorHelper _userGeneratorHelper = new UserGeneratorHelper();

        [Fact]
        public void GeneratePersonalCode_NotNull()
        {
            var personalCode = _userGeneratorHelper.GeneratePersonalCode(DateTime.Now, Gender.Male);

            Assert.NotNull(personalCode);
        }

        [Fact]
        public void GeneratePersonalCode_1999_Male()
        {
            var personalCode = _userGeneratorHelper.GeneratePersonalCode(new DateTime(1999,1, 1), Gender.Male);

            var firstSevenDigits = personalCode.Substring(0, 7);

            Assert.Equal("3990101", firstSevenDigits);
        }

        [Fact]
        public void GeneratePersonalCode_1999_Female()
        {
            var personalCode = _userGeneratorHelper.GeneratePersonalCode(new DateTime(1999, 1, 1), Gender.Female);

            var firstSevenDigits = personalCode.Substring(0, 7);

            Assert.Equal("4990101", firstSevenDigits);
        }

        [Fact]
        public void GeneratePersonalCode_2000_Male()
        {
            var personalCode = _userGeneratorHelper.GeneratePersonalCode(new DateTime(2000, 1, 1), Gender.Male);

            var firstSevenDigits = personalCode.Substring(0, 7);

            Assert.Equal("5000101", firstSevenDigits);
        }

        [Fact]
        public void GeneratePersonalCode_2000_Female()
        {
            var personalCode = _userGeneratorHelper.GeneratePersonalCode(new DateTime(2000, 1, 1), Gender.Female);

            var firstSevenDigits = personalCode.Substring(0, 7);

            Assert.Equal("6000101", firstSevenDigits);
        }
    }
}
