using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RecipesSystem.AppServer.Data;
using RecipesSystem.AppServer.Models;
using static DP.USDAparamsDTO;


namespace RecipesSystem.AppServer.Controllers
{
    public class RecipesController : Controller
    {
        private readonly RecipesSystemAppServerContext _context;
     

        public RecipesController(RecipesSystemAppServerContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
             return View(await _context.Recipe.ToListAsync());
           
        }

        // GET: Recipes/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,PrepInstructions,Ingredients,ImageURL,TimeToMake,CookingTime,Diners,Tag,Nutriants,Holiday,Weather")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
               
                ImaggaAdapter Iadapter = new ImaggaAdapter();
                string Message = Iadapter.Check(recipe.Name, recipe.ImageURL,recipe.Tag.ToString());
                if (Message == "\"good image\"")//check uf the umage mach the recipe
                {
                    _context.Add(recipe);
                   
                    await _context.SaveChangesAsync();
                    //Allows the user to see the recipe he entered and decide whether to edit or delete it
                    return RedirectToAction("OneRecipe", new {recipe.Id});
                }
                else
                    ModelState.AddModelError(string.Empty, Message);
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,PrepInstructions,Ingredients,ImageURL,TimeToMake,CookingTime,Diners,Tag,Nutriants,Holiday,Weather")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model = await _context.Recipe.FindAsync(id);
                    Recipe r = new Recipe();
                    r.Id = recipe.Id;
                    r.Rate=recipe.Rate;
                    r.Note= recipe.Note;
                    //Inserts the updated data into the database again after deleting the previous recipe that was edited
                    if (recipe.ImageURL==null)
                    {
                        r.ImageURL=model.ImageURL;
                    }
                    else
                    {
                        r.ImageURL=recipe.ImageURL;
                    }
                    if (recipe.Name==null)
                    {
                        r.Name = model.Name;

                    }
                    else
                    {
                        r.Name = recipe.Name;
                    }
                    if(recipe.CookingTime==null)
                    {
                        r.CookingTime = model.CookingTime;
                    }
                    else
                    {
                        r.CookingTime = recipe.CookingTime;
                    }
                    if(recipe.Ingredients==null)
                    {
                        r.Ingredients =model.Ingredients;
                    }
                    else
                    {
                       r.Ingredients=recipe.Ingredients;
                    }
                    if (recipe.Diners ==0)
                    {
                        r.Diners = model.Diners;
                    }
                    else
                    {
                        r.Diners = recipe.Diners;
                    }
                    if (recipe.TimeToMake== null)
                    {
                        r.TimeToMake = model.TimeToMake;
                    }
                    else
                    {
                        r.TimeToMake = recipe.TimeToMake;
                    }
                    if (recipe.Tag== 0)
                    {
                        r.Tag = model.Tag;
                    }
                    else
                    {
                        r.Tag = recipe.Tag;
                    }
                    if (recipe.Tag == 0)
                    {
                        r.Description= model.Description;
                    }
                    else
                    {
                        r.Description = recipe.Description;
                    }
                    if (recipe.Tag == 0)
                    {
                        r.PrepInstructions = model.PrepInstructions;
                    }
                    else
                    {
                        r.PrepInstructions = recipe.PrepInstructions;
                    }                 
         
                    _context.Remove(model);
                    _context.Add(r);
                 
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipe == null)
            {
                return Problem("Entity set 'tryDbuContext.Recipe'  is null.");
            }
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }

        public async Task<IActionResult> About()
        {
           //will receive a list of the most recommended recipes and display three of them
            var TopRecipes=_context.Recipe.Where(r=>r.Rate=="5").ToList();

            return View(TopRecipes);
        }

        //Allows the user to rate the recipe
        public async Task<IActionResult> Rate(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Rate(int id, [Bind("Id,Name,Description,PrepInstructions,Ingredients,ImageURL,TimeToMake,CookingTime,Diners,Tag,Nutriants, Rate,Note,Holiday,Weather")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }
                try
                {
                    var model = await _context.Recipe.FindAsync(id);
                    Recipe r = new Recipe();
                    r.Id = recipe.Id;
                    r.Rate = recipe.Rate;
                    r.Note = recipe.Note;
                    r.ImageURL = model.ImageURL;
                    r.Name = model.Name;
                    r.CookingTime = model.CookingTime;
                    r.Ingredients = model.Ingredients;
                    r.Diners = model.Diners;
                    r.TimeToMake = model.TimeToMake;
                    r.Tag = model.Tag;     
                    r.Description = model.Description;       
                    r.PrepInstructions = model.PrepInstructions;
                 
                    WeatherAdapter Wadapter = new WeatherAdapter();
                    int Message = Wadapter.Check("Jerusalem");
                    if(Message== 1)//A function that gives me the data of the current weather according to the recommendation
                {
                        r.Weather = Weathers.HOT;
                    }
                    else if(Message== 0)
                    {
                        r.Weather = Weathers.COLD;
                    }
                    else
                    {
                        r.Weather = Weathers.NICE;
                    }
                    HebCalAdapter Hadapter = new HebCalAdapter();
                    int MsgHeb = Hadapter.Check();
                    if (MsgHeb== 1)
                    {
                        r.Holiday = Holidays
                            .SUKOT;
                    }
                    else if (MsgHeb ==3 )
                    {
                       
                        r.Holiday = Holidays.PESACH;
                    }
                    else if (MsgHeb == 5)
                    {
                        r.Holiday = Holidays.PURIM;
                    }
                    else if (MsgHeb == 0)
                    {
                        r.Holiday = Holidays.ROSH_HASHANA;
                    }
                    else if (MsgHeb == 4)
                    {
                        r.Holiday = Holidays.CHANUKA;
                    }
                    else if (MsgHeb ==2)
                    {
                        r.Holiday = Holidays.SHAVUOT;
                    }
                    else
                    {
                        r.Holiday = Holidays.NOTHOLIDAY;
                    }

                    _context.Remove(model);
                    _context.Add(r);
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));



        }

        public IActionResult Error404()
        {
            return View();
        }

        public async Task<IActionResult> Recipes()
        {

            return View(await _context.Recipe.ToListAsync());
        }

        //Presentation of a recipe and its details
        public async Task<IActionResult> SingleRecipe(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var recipe = await _context.Recipe.FirstOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
           
            return View(recipe);
        }

        //Allows you to see all the existing categories of the recipes
        public async Task<IActionResult> Tags()
        {
         
            return View(await _context.Recipe.ToListAsync());
        }

        //The recipe the person just added to Recipes will be displayed here to
        //allow them to make changes to the recipe as well
        public async Task<IActionResult> OneRecipe(int? id)
        {

            if (id == null)
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

        //will display a list filtered by the category of the recipe
        public async Task<IActionResult> TagTemplate(Tags? t)
        {
            IEnumerable<Recipe> recipes=new List<Recipe>();

            if (t != null) 
                recipes =  _context.Recipe.Where(m => m.Tag == t);
               
            
            return View(recipes);

        }

        //will display a filtered list according to the recipes recommended for the current weather
        public async Task<IActionResult> Weather(int t)
        {
            IEnumerable<Recipe> recipes = new List<Recipe>();        
            recipes = _context.Recipe.Where(m =>m.Weather==(Weathers)t);
            return View(recipes);

        }

        //will present a filtered list according to the recommended recipes for the upcoming holidays
        public async Task<IActionResult> Holyday(int t)
        {
            IEnumerable<Recipe> recipes = new List<Recipe>();
            recipes = _context.Recipe.Where(m => m.Holiday == (Holidays)t );
            return View(recipes);

        }



    }
}



