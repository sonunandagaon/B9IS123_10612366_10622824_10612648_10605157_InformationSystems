using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicEquipmentStore.Data;
using MusicEquipmentStore.Models;
using MusicEquipmentStore.Models.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace MusicEquipmentStore.Controllers
{
    public class HomeController : Controller
    {
        protected MusicEquipmentStoreContext _dbContext;
        public HomeController(MusicEquipmentStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var data = _dbContext.Users.Where(u => u.Username == loginViewModel.Username).SingleOrDefault();
                if (data != null)
                {
                    var isValid = (data.Username == loginViewModel.Username && data.Password == loginViewModel.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginViewModel.Username) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", loginViewModel.Username);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid Password!";
                        return View(loginViewModel);
                    }
                }
                else
                {
                    TempData["errorUserName"] = "UserName Not Found!";
                    return View(loginViewModel);
                }
            }
            else
            {
                return View(loginViewModel);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}