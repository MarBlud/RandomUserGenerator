using RandomUserGenerator.Models;

namespace RandomUserGenerator.Repositories.Interfaces
{
    public interface IRandomUserRepository
    {
        public string GetRandomName(Gender gender);

        public string GetRandomSurname(Gender gender);

        public string GetRandomCitizenship();
    }
}
