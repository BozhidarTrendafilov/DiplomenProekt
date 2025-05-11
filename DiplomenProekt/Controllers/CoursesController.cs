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
        [HttpPost]
        public async Task<IActionResult> ActivateAndRedirect()
        {
            var user = await _userManager.GetUserAsync(User);

            if(user != null)
            {
                user.HasPaidSubscription = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home");
            }
            return Redirect("/Identity/Account/Login");
        }
        public async Task<IActionResult> Course()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            if (!user.HasPaidSubscription)
            {
                return RedirectToAction("pricing", "Home");
            }
            return View();
        }
        public IActionResult payment()
        {
            return View();
        }
    }
}
