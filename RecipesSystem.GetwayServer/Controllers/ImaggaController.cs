﻿using Microsoft.AspNetCore.Mvc;
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
        public string Get(string title="pizza",string imageURL= "https://medias.hashulchan.co.il/www/uploads/2020/12/shutterstock_658408219-600x600.jpg")
        {
            BL.ImaggaLogic bl = new BL.ImaggaLogic();
            ImaggaParamsDTO dp=new ImaggaParamsDTO {Title=title,ImageUrl=imageURL};
            return bl.IsGoodPic(dp);
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
