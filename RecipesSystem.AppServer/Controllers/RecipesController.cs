using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using RecipesSystem.AppServer.Data;
using RecipesSystem.AppServer.Models;


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
            //HebCalAdapter Hadapter = new HebCalAdapter();
            //string Message = Hadapter.Check();
            //ViewData["HebCalMessage"] = Message;

            //WeatherAdapter Wadapter = new WeatherAdapter();
            //Message = Wadapter.Check("Jerusalem");
            //ViewData["WeatherMessage"] = Message;

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
                //add the nutrients
                GetNutriants(recipe);
                ImaggaAdapter Iadapter = new ImaggaAdapter();
                string Message = Iadapter.Check(recipe.Name, recipe.ImageURL,recipe.Tag.ToString());
                if (Message == "\"good image\"")//בדיקה אם התמונה טובה
                {
                    _context.Add(recipe);
                   
                    await _context.SaveChangesAsync();
                   
                    return RedirectToAction("OneRecipe", new {recipe.Id});
                }
                else
                    ModelState.AddModelError(string.Empty, Message);
            }
            return View(recipe);
        }

        //use the api server to insert the nutrients of the recipe
        public void GetNutriants(Recipe recipe)
        {
            
            USDAadapter Uadapter = new USDAadapter();
            List<DP.USDAparamsDTO.Nutrient> nutriants = Uadapter.Check(recipe.Name, recipe.Tag.ToString());
            recipe.Nutriants= new List<Nutriant>();
            Nutriant nutrient=new Nutriant();
            foreach(DP.USDAparamsDTO.Nutrient nutr in nutriants)
            {
                nutrient.Value = nutr.Value;
                nutrient.Name = nutr.Name;
                nutrient.UnitOfMesurment = nutr.UnitName;//לא בטוחה שזה המקביל שלו אבל נבדוק
                recipe.Nutriants.Add(nutrient);
            }


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
                    if(recipe.ImageURL==null)
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
               
                    r.Nutriants = new List<Nutriant>();
                    if(model.Nutriants != null)
                    { 
                    foreach(var item in model.Nutriants)
                    {
                        r.Nutriants.Add(item);
                    }
                    }
                    _context.Remove(model);
                    _context.Add(r);
                    //_context.Update(r);
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
            //יקבל רשימה של המתכונים הכי מומלצים ויציחג שלוש מתוכם
            var TopRecipes=_context.Recipe.Where(r=>r.Rate=="5").ToList();

            return View(TopRecipes);
        }

    
        public async Task<IActionResult> Contact(int? id)
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
        public async Task<IActionResult>Contact(int id, [Bind("Id,Name,Description,PrepInstructions,Ingredients,ImageURL,TimeToMake,CookingTime,Diners,Tag,Nutriants, Rate,Note,Holiday,Weather")] Recipe recipe)
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
                    if (recipe.ImageURL == null)
                    {
                        r.ImageURL = model.ImageURL;
                    }
                    else
                    {
                        r.ImageURL = recipe.ImageURL;
                    }
                    if (recipe.Name == null)
                    {
                        r.Name = model.Name;

                    }
                    else
                    {
                        r.Name = recipe.Name;
                    }
                    if (recipe.CookingTime == null)
                    {
                        r.CookingTime = model.CookingTime;
                    }
                    else
                    {
                        r.CookingTime = recipe.CookingTime;
                    }
                    if (recipe.Ingredients == null)
                    {
                        r.Ingredients = model.Ingredients;
                    }
                    else
                    {
                        r.Ingredients = recipe.Ingredients;
                    }
                    if (recipe.Diners == 0)
                    {
                        r.Diners = model.Diners;
                    }
                    else
                    {
                        r.Diners = recipe.Diners;
                    }
                    if (recipe.TimeToMake == null)
                    {
                        r.TimeToMake = model.TimeToMake;
                    }
                    else
                    {
                        r.TimeToMake = recipe.TimeToMake;
                    }
                    if (recipe.Tag == 0)
                    {
                        r.Tag = model.Tag;
                    }
                    else
                    {
                        r.Tag = recipe.Tag;
                    }
                    if (recipe.Tag == 0)
                    {
                        r.Description = model.Description;
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

                    r.Nutriants = new List<Nutriant>();
                    if (model.Nutriants != null)
                    {
                        foreach (var item in model.Nutriants)
                        {
                            r.Nutriants.Add(item);
                        }
                    }
                    WeatherAdapter Wadapter = new WeatherAdapter();
                    int Message = Wadapter.Check("Jerusalem");
                    if(Message== 1)//פונקציה שמכניסה לי את הנתון של מצז האויר הנוכחי לפי ההמלצה
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
                    //_context.Update(r);
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
            //GetNutriants(id);
            return View(recipe);
        }

        public async Task<IActionResult> Tags()
        {
            //return View();
            return View(await _context.Recipe.ToListAsync());
        }


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

        public async Task<IActionResult> TagTemplate(Tags? t)//יציג רשימה מסוננת לפי הקטגוריה של המתכון
        {
            IEnumerable<Recipe> recipes=new List<Recipe>();

            if (t != null) 
                recipes =  _context.Recipe.Where(m => m.Tag == t);
               
            
            return View(recipes);

        }

        public async Task<IActionResult> Holyday_Weather(int t)//יציג רשימה מסוננת לפי הקטגוריה של המתכון
        {
            IEnumerable<Recipe> recipes = new List<Recipe>();

            if (t != null)
                recipes = _context.Recipe.Where(m => m.Holiday==(Holidays)t||m.Weather==(Weathers)t);
            return View(recipes);

        }

    }
}



