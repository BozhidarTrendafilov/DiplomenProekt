using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using DiplomenProekt.Models;

namespace DiplomenProekt.Controllers
{
    public class CoursesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public CoursesController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Courses()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (!user.HasPaidSubscription)
            {
                return View("pricing");
            }
            return View();
        }
    }
}
