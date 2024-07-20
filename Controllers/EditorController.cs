using System.Security.Claims;
using crud_app.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace crud_app.Controllers;

public class EditorController(CrudApplicationContext db) : Controller
{
    private readonly CrudApplicationContext _db = db;
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(Editor editor)
    {
        if (_db.Editors.Any(ed => ed.Login!.Equals(editor.Login)
                                  && ed.Password!.Equals(editor.Password)))
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, editor.Login!));
            var claimsIndentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIndentity));
            return RedirectToAction("Index", "Customer");
        }

        ViewBag.ErrorMessage = "Invalid login or password";
        return View();
    }
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(Editor editor)
    {
        if (_db.Editors.Any(ed => ed.Login!.Equals(editor.Login)))
        {
            ModelState.AddModelError("login", "This login already exists");
        }

        if (ModelState.IsValid)
        {
            _db.Editors.Add(editor);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Customer");
    }
}