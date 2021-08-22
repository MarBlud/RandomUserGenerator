using Microsoft.AspNetCore.Mvc;
using RandomUserGenerator.Logic.Interfaces;
using RandomUserGenerator.Models.Dtos;

namespace RandomUserGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomUserController : ControllerBase
    {
        private readonly IRandomUserLogic _randomUserLogic;

        public RandomUserController(IRandomUserLogic randomUserLogic)
        {
            _randomUserLogic = randomUserLogic;
        }

        [HttpGet]
        public IActionResult GetRandomUser()
        {
            var randomUser = _randomUserLogic.GenerateRandomUser();

            if(randomUser is null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Name = randomUser.Name,
                Surname = randomUser.Surname,
                Age = randomUser.Age,
                Citizenship = randomUser.Citizenship,
                Birthdate = randomUser.Birthdate.ToString("yyyy-MM-dd"),
                Gender = randomUser.Gender.ToString(),
                PersonalCode = randomUser.PersonalCode,
                PhoneNumber = randomUser.PhoneNumber
            };

            return Ok(userDto);
        }
    }
}
