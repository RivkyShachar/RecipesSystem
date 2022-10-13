
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RecipesSystem.AppServer.Models;
using System.Diagnostics;

namespace RecipesSystem.AppServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //IFirebaseClient client;
        //IFirebaseConfig config = new FirebaseConfig
        //{
        //    AuthSecret = "OFkkezOWr12hCkSqWc1mN5QgOoV205UckwHQWZzg",
        //    BasePath = "https://recipessystem-8404a-default-rtdb.firebaseio.com/"
        //};



        // GET: HomeController
        public ActionResult Index()
        {
            string authSecret = "OFkkezOWr12hCkSqWc1mN5QgOoV205UckwHQWZzg";
            string basePath = "https://recipessystem-8404a-default-rtdb.firebaseio.com/";
            string senderAppName = "myRecipes";


            //client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response1 = client.Get("NewRecipe");

            //if (response1.Body != "null")
            //{
            //    dynamic data1 = JsonConvert.DeserializeObject<dynamic>(response1.Body);
            //    var list = new List<NewRecipe>();
            //    foreach (var item in data1)
            //    {
            //        list.Add(JsonConvert.DeserializeObject<NewRecipe>(((JProperty)item).Value.ToString()));
            //    }




            //    return View(list);








            //}

            //if (client != null && !string.IsNullOrEmpty(basePath))
            //{

            //    NewRecipe newRecipe1 = new NewRecipe { CookingTime = "30 min", Description = "fish", ImageURL = "theurl", KeyWord = "c", MakingTime = "50 min", PrepInstructions = "add,mix,dkdf" };
            //    PushResponse response2 = client.Push("NewRecipe/", newRecipe1);
            //    newRecipe1.Id = response2.Result.name;
            //    SetResponse setResponse = client.Set("NewRecipe/" + newRecipe1.Description, newRecipe1);
            //    //var data = new
            //    //{
            //    //    Name = "Test",
            //    //    Mobile = "123456"
            //    //};
            //    //var response = client.Push("doc/", data);
            //}
            return View();
        }

        // GET: HomeController/Details/5
        [HttpGet]
        public ActionResult Details(string description)
        {
            //client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = client.Get("NewRecipe/" + description);
            //NewRecipe data = JsonConvert.DeserializeObject<NewRecipe>(response.Body);
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public ActionResult Create(NewRecipe newRecipe)
        {
            try
            {
                AddStudentToFirebase(newRecipe);
                ModelState.AddModelError(string.Empty, "Added Successfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        private void AddStudentToFirebase(NewRecipe newRecipe)
        {
        //    client = new FireSharp.FirebaseClient(config);
        //    var data = newRecipe;
        //    PushResponse response = client.Push("NewRecipe/", data);
        //    data.Id = response.Result.name;
        //    SetResponse setResponse = client.Set("NewRecipe/" + data.Description, data);
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //// POST: HomeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        public ActionResult Edit(string id)
        {
            //client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = client.Get("NewRecipe/" + id);
            //NewRecipe data = JsonConvert.DeserializeObject<NewRecipe>(response.Body);
            return View();
        }

        [HttpPost]
        public ActionResult Edit(NewRecipe newRecipe)
        {
            //client = new FireSharp.FirebaseClient(config);
            //SetResponse response = client.Set("NewRecipe/" + newRecipe.Description, newRecipe);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string description)
        {
            //client = new FireSharp.FirebaseClient(config);
            //FirebaseResponse response = client.Delete("NewRecipe/" + description);
            return RedirectToAction("Index");
        }
    }
}




  