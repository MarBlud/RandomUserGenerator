using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomUserGenerator.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public string Citizenship { get; set; }
    }
}
