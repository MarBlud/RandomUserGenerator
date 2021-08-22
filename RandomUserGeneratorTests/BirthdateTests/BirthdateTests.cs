using RandomUserGenerator.Helpers;
using System;
using Xunit;

namespace RandomUserGeneratorTests.BirthdateTests
{
    public class BirthdateTests
    {
        private readonly UserGeneratorHelper _userGeneratorHelper = new UserGeneratorHelper();

        [Fact]
        public void GenerateBirthdate_BirthdateMakesSense()
        {
            var birthdate = _userGeneratorHelper.GenerateBirthdate();

            Assert.True(birthdate > new DateTime(1900, 1, 1));
        }
    }
}
