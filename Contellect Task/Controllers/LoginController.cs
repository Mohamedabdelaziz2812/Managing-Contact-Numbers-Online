using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Contellect_Task.Controllers;

public class LoginController : Controller
{
    // Hardcoded users
    private readonly Dictionary<string, string> validUsers = new Dictionary<string, string>
        {
            { "user1", "user1" },
            { "user2", "user2" }
        };

    // GET: Login Page
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            if (validUsers.ContainsKey(model.Username) && validUsers[model.Username] == model.Password)

            {
                // Create claims for the authenticated user
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid Username or Password";
        }
        return View(model);
    }
}

