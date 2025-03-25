using Microsoft.AspNetCore.Mvc;
using PetNameGenerator;
using PetNameGenerator.Constants;

namespace RandomNameGenerator.API.Controllers
{
    [ApiController]
    [Route("petname")]
    public class RandomNameController : ControllerBase
    {
        [HttpPost("generate")]
        public IActionResult Post([FromQuery] AnimalType animalType, bool hasLastName)
        {
            string firstName = "";
            string lastName = "";
            Random rmd = new Random();
            int randomIndex = rmd.Next(0, 5);

            if (animalType == AnimalType.Dog)
            {
                firstName = Names.Dog.First[randomIndex];
                if (hasLastName)
                {
                    randomIndex = rmd.Next(0, 5);
                    lastName = Names.Dog.Last[randomIndex];
                }
            }

            else if (animalType == AnimalType.Cat)
            {
                firstName = Names.Cat.First[randomIndex];
                if (hasLastName)
                {
                    randomIndex = rmd.Next(0, 5);
                    lastName = Names.Cat.Last[randomIndex];
                }
            }

            else if (animalType == AnimalType.Bird)
            {
                firstName = Names.Bird.First[randomIndex];
                if (hasLastName)
                {
                    randomIndex = rmd.Next(0, 5);
                    lastName = Names.Bird.Last[randomIndex];
                }
            }

            else
            {
                return BadRequest();
            }

            return Ok(string.Concat(firstName,"-", lastName));
        }

    }
}
