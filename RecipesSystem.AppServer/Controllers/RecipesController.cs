﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            HebCalAdapter Hadapter = new HebCalAdapter();
            string Message = Hadapter.Check();
            ViewData["HebCalMessage"] = Message;
            WeatherAdapter Wadapter = new WeatherAdapter();
            Message = Wadapter.Check("Haifa");
            ViewData["WeatherMessage"] = Message;
            ImaggaAdapter Iadapter = new ImaggaAdapter();
            Message = Iadapter.Check("pizza", "https://medias.hashulchan.co.il/www/uploads/2020/12/shutterstock_658408219-600x600.jpg");
            ViewData["ImaggaMessage"] = Message;
            USDAadapter Uadapter = new USDAadapter();
            Message = Uadapter.Check("pizza", "x");
            ViewData["USDAMessage"] = Message;
            return View(await _context.Recipe.ToListAsync());
            //return View();
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
        public async Task<IActionResult> Create([Bind("Id,Description,PrepInstructions,Tools,Ingredients,TimeToName,ImageURL,TimeToMake,CookingTime,Diners,Tag")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,PrepInstructions,Tools,Ingredients,TimeToName,ImageURL,TimeToMake,CookingTime,Diners,Tag")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
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

            var student = await _context.Recipe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
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
        public IActionResult OneRecipe()
        {
            return View();
        }
    }
}



