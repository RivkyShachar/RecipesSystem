using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipesSystem.AppServer.Data;
using RecipesSystem.AppServer.Models;
//using FireSharp.Config;
//using FireSharp.Interfaces;
//using FireSharp.Response;

namespace RecipesSystem.AppServer.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipesSystemAppServerContext _context;
        //IFirebaseConfig config = new FirebaseConfig
        //{
        //    AuthSecret = "OFkkezOWr12hCkSqWc1mN5QgOoV205UckwHQWZzg",
        //    BasePath = "https://recipessystem-8404a-default-rtdb.firebaseio.com/"
        //};
        //IFirebaseClient client;

        public RecipesController(RecipesSystemAppServerContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            HebCalAdapter Hadapter = new HebCalAdapter();
            string Message = Hadapter.Check();
            ViewData["HebCalMessage"] = Message;
            WeatherAdapter Wadapter = new WeatherAdapter();
            Message = Wadapter.Check("Haifa");
            ViewData["WeatherMessage"] = Message;
            ImaggaAdapter Iadapter = new ImaggaAdapter();
            Message = Iadapter.Check("pizza","https://medias.hashulchan.co.il/www/uploads/2020/12/shutterstock_658408219-600x600.jpg");
            ViewData["ImaggaMessage"] = Message;
            USDAadapter Uadapter=new USDAadapter();
            Message = Uadapter.Check("pizza", "x");
            ViewData["USDAMessage"] = Message;
            //return View(await _context.Recipe.ToListAsync());
            return View();
        }

        //GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create

        [HttpPost]
        public ActionResult Create(Recipe newRecipe)
        {
            try
            {
              
                ModelState.AddModelError(string.Empty, "Added Successfully");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

      

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult Recipes()
        {

            return View();
        }
        public IActionResult SingleRecipe()
        {
            return View();
        }
        public IActionResult Tags()
        {
            return View();
        }
        public IActionResult TagTemplate()
        {
            return View();
        }
    }
}
