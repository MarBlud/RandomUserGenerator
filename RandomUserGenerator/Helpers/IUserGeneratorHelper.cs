using RandomUserGenerator.Models;
using System;

namespace RandomUserGenerator.Helpers
{
    public interface IUserGeneratorHelper
    {
        DateTime GenerateBirthdate();
        string GeneratePersonalCode(DateTime birthdate, Gender gender);
        string GeneratePhoneNumber();
        Gender GetRandomGender();
    }
}