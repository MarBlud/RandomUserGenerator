using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomUserGenerator.Models.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PersonalCode { get; set; }

        public string PhoneNumber { get; set; }

        public int Age { get; set; }

        public string Birthdate { get; set; }

        public string Gender { get; set; }

        public string Citizenship { get; set; }
    }
}
