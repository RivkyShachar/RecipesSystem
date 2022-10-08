using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RecipesSystem.AppServer.Data;
using RecipesSystem.AppServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Authentication;


namespace RecipesSystem.AppServer.Controllers
{
    [Authorize]
    public class tryController : Controller
    {
        //private readonly RecipesSystemAppServerContext _context;

        //public tryController(RecipesSystemAppServerContext context)
        //{
        //    _context = context;
        //}


        public const string AuthenticationScheme="";
        public void AddAuthentication(string defaultScheme = "defaulte") { }
        //public AuthenticationBuilder AddAuthentication(this IServiceCollection services);
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "oHU6Of5kBX6xhgbTQTCjugE2ppPu8j59NkkDmfgz",
            BasePath = "https://myrecipes-6198e-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        // GET: Student
        public ActionResult Index()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("NewRecipe");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<NewRecipe>();
            foreach (var item in data)
            {
                list.Add(JsonConvert.DeserializeObject<NewRecipe>(((JProperty)item).Value.ToString()));
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

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
            client = new FireSharp.FirebaseClient(config);
            var data = newRecipe;
            PushResponse response = client.Push("NewRecipe/", data);
            data.Id = response.Result.name;
            SetResponse setResponse = client.Set("NewRecipe/" + data.Id, data);
        }


        //[HttpGet]
        //public ActionResult Detail(string id)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = client.Get("NewRecipe/" + id);
        //    NewRecipe data = JsonConvert.DeserializeObject<NewRecipe>(response.Body);
        //    return View(data);
        //}

        //[HttpGet]
        //public ActionResult Edit(string id)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = client.Get("NewRecipe/" + id);
        //    NewRecipe data = JsonConvert.DeserializeObject<NewRecipe>(response.Body);
        //    return View(data);
        //}

        //[HttpPost]
        //public ActionResult Edit(NewRecipe newRecipe)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    SetResponse response = client.Set("NewRecipe/" + newRecipe.Id, newRecipe);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Delete(string id)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = client.Delete("NewRecipe/" + id);
        //    return RedirectToAction("Index");
        //}

    }
}