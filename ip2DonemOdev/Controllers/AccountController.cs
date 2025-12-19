using ip2DonemOdev.DAL.Context;
using ip2DonemOdev.DAL.Entities;
using ip2DonemOdev.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ip2DonemOdev.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyContext _context;

        public AccountController()
        {
            _context = new MyContext();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (_context.Users.Any(u => u.Email == model.Email))
            {
                ModelState.AddModelError("", "Bu e-posta zaten kayıtlı.");
                return View(model);
            }

            var user = new User
            {
                Email = model.Email,
                IsAdmin = false,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password) 
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null)
            {
                bool passwordCheck = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);

                if (passwordCheck)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.Role, "User") 
                    };

                    if (user.IsAdmin)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, "Admin")); // Admin ise ekstra Admin rolü ekle
                    }
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Email veya şifre yanlış.");
            return View(model);
        }

        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
