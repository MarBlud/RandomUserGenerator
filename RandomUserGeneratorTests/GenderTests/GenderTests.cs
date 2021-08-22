using RandomUserGenerator.Helpers;
using RandomUserGenerator.Models;
using System.Collections.Generic;
using Xunit;

namespace RandomUserGeneratorTests.RandomUserGeneratorTests.RandomGenderTests
{
    public class GenderTests
    {
        private readonly UserGeneratorHelper _userGeneratorHelper = new UserGeneratorHelper();

        [Fact]
        public void GetRandomGender_IsOfTypeGender()
        {
            var gender = _userGeneratorHelper.GetRandomGender();

            Assert.IsType<Gender>(gender);
        }

        [Fact]
        public void GetRandomGender_IsEitherMaleOrFemale()
        {
            var genders = new List<string> { "Male", "Female" };

            var gender = _userGeneratorHelper.GetRandomGender();

            Assert.Contains(gender.ToString(), genders);
        }
    }
}
