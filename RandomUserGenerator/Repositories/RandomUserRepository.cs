using RandomUserGenerator.Models;
using RandomUserGenerator.Repositories.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace RandomUserGenerator.Repositories
{
    public class RandomUserRepository : IRandomUserRepository
    {
        public string GetRandomCitizenship()
        {
            var fileName = "Citizenships.txt";

            var randomCitizenship = ReadRandomLineInFile(fileName);

            return randomCitizenship;
        }

        public string GetRandomName(Gender gender)
        {
            var fileName = 
                gender == Gender.Female ? "FemaleNames.txt" : "MaleNames.txt";

            var randomName = ReadRandomLineInFile(fileName);

            return randomName;
        }

        public string GetRandomSurname(Gender gender)
        {
            var fileName =
                gender == Gender.Female ? "FemaleSurnames.txt" : "MaleSurnames.txt";

            var randomSurname = ReadRandomLineInFile(fileName);

            return randomSurname;
        }


        private string ReadRandomLineInFile(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Data\\{fileName}");

            var numberOfEntries = int.Parse(File.ReadLines(path).First());

            var randomEntry = new Random().Next(1, numberOfEntries);

            var entry = File.ReadLines(path).ElementAtOrDefault(randomEntry);

            return entry;
        }
    }
}
