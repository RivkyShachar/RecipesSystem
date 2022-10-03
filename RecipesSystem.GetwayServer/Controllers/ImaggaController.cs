using Microsoft.AspNetCore.Mvc;
using DP;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesSystem.GetwayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImaggaController : ControllerBase
    {
        // GET: api/<ImaggaController>
        [HttpGet]
        public string Get()
        {
            BL.ImaggaLogic bl = new BL.ImaggaLogic();
            DP.ImaggaParamsDTO dp=new ImaggaParamsDTO();
            dp.Title = "pizza";
            dp.ImageUrl = "https://medias.hashulchan.co.il/www/uploads/2020/12/shutterstock_658408219-600x600.jpg";
            string result=bl.IsGoodPic(dp);
            return result;
        }

        // GET api/<ImaggaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImaggaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImaggaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImaggaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
