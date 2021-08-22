using RandomUserGenerator.Helpers;
using Xunit;

namespace RandomUserGeneratorTests.RandomCitizenshipTests
{
    public class PhoneNumberTests
    {
        private readonly UserGeneratorHelper _userGeneratorHelper = new UserGeneratorHelper();

        [Fact]
        public void GeneratePhoneNumber_IsNotNull()
        {
            var phoneNumber = _userGeneratorHelper.GeneratePhoneNumber();

            Assert.NotNull(phoneNumber);
        }

        [Fact]
        public void GeneratePhoneNumber_IsCorrectLength()
        {
            var phoneNumber = _userGeneratorHelper.GeneratePhoneNumber();

            Assert.Equal(12, phoneNumber.Length);
        }

        [Fact]
        public void GeneratePhoneNumber_IsCorrectFormat()
        {
            var phoneNumber = _userGeneratorHelper.GeneratePhoneNumber();

            var internationalPhoneNumberRegex = @"^((\+\d{1,3}(-| )?\(?\d\)?(-| )?\d{1,5})|(\(?\d{2,6}\)?))(-| )?(\d{3,4})(-| )?(\d{4})(( x| ext)\d{1,5}){0,1}$";

            Assert.Matches(internationalPhoneNumberRegex, phoneNumber);
        }
    }
}
