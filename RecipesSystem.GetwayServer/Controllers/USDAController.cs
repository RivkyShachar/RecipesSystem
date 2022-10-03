using Microsoft.AspNetCore.Mvc;
using static DP.USDAparamsDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesSystem.GetwayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class USDAController : ControllerBase
    {
        // GET: api/<USDAController>
        [HttpGet]
        public Nutrient[] Get()
        {
            BL.USDAlogic bl = new BL.USDAlogic();
            var result = bl.GetNutrientsValues("pizza");
            return result;
        }

        // GET api/<USDAController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<USDAController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<USDAController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<USDAController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
