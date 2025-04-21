using DiplomenProekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiplomenProekt.Controllers
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

        public IActionResult about()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult faq() 
        { 
            return View();
        }

        public IActionResult pricing()
        {
            return View();
        }

        public IActionResult _LoginPartial()
        {
            return View();
        }
        public IActionResult courses()
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