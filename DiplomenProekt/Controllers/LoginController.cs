using Microsoft.AspNetCore.Mvc;

namespace DiplomenProekt.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
