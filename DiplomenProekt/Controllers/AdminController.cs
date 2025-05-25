using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DiplomenProekt.Models;

public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AdminController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IActionResult> AdminPage()
    {
        var user = await _userManager.GetUserAsync(User);
        ViewBag.IsAdmin = user?.IsAdmin ?? false;

        var users = _userManager.Users.ToList();

        return View(users);

        // Списък с потребители
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null) return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        return View(user);
    }

    // Редактиране - обработва формата
    [HttpPost]
    public async Task<IActionResult> Edit(ApplicationUser model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByIdAsync(model.Id);
        if (user == null) return NotFound();

        user.Email = model.Email;
        user.UserName = model.UserName;
        user.HasPaidSubscription = model.HasPaidSubscription;
        user.IsAdmin = model.IsAdmin;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
            return RedirectToAction("AdminPage");

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }

    // Delete GET - потвърждение
    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null) return NotFound();

        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        return View(user);
    }

    // Delete POST - изпълнява изтриването
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return NotFound();

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
            return RedirectToAction("AdminPage");

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(user);
    }
}
