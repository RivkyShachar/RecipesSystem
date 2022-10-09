using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RecipesSystem.AppServer.Models;
using System.Diagnostics;
//HebHolidayAdapter Hadapter = new HebHolidayAdapter();
//WeatherAdapter Wadapter = new WeatherAdapter();
//string Message = Hadapter.Check();
//ViewData["HolidayMessage"] = Message;
//Message = Wadapter.Check("Haifa");
//ViewData["WeatherMessage"] = Message;
//return View(await _context.Recipe.ToListAsync());
namespace RecipesSystem.AppServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string authSecret = "oHU6Of5kBX6xhgbTQTCjugE2ppPu8j59NkkDmfgz";
            string basePath = "https://myrecipes-6198e-default-rtdb.asia-southeast1.firebasedatabase.app/";
            string senderAppName = "myRecipes";

            IFirebaseClient client;
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = authSecret,
                BasePath = basePath
            };

            client=new FireSharp.FirebaseClient(config);
            FirebaseResponse response1 = client.Get("myRecipes");

            if(response1.Body!="null")
            {
                dynamic data1 = JsonConvert.DeserializeObject<dynamic>(response1.Body);
                var list = new List<NewRecipe>();
                foreach (var item in data1)
                {
                    list.Add(JsonConvert.DeserializeObject<NewRecipe>(((JProperty)item).Value.ToString()));
                }
            }
            
            if (client!=null &&!string.IsNullOrEmpty(basePath))
            {

                NewRecipe newRecipe1 = new NewRecipe { CookingTime = "c", Description = "d", ImageURL = "i", KeyWord = "k", MakingTime = "m", PrepInstructions = "p" };
                PushResponse response2 = client.Push("NewRecipe/", newRecipe1);
                newRecipe1.Id = response2.Result.name;
                SetResponse setResponse = client.Set("NewRecipe/" + newRecipe1.Description, newRecipe1);
                //var data = new
                //{
                //    Name = "Test",
                //    Mobile = "123456"
                //};
                //var response = client.Push("doc/", data);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}