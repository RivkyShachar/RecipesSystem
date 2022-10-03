using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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