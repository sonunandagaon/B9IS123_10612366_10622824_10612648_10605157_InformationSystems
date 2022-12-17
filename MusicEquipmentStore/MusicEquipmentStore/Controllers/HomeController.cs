using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicEquipmentStore.Context;
//using MusicEquipmentStore.Data;
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

        //[Authorize]
        public async Task<IActionResult> Index(string categorySlug = "", int p = 1)
        {
            int pageSize = 3;
            ViewBag.PageNumber = p;
            ViewBag.PageRange = pageSize;
            ViewBag.CategorySlug = categorySlug;

            if (categorySlug == "")
            {
                ViewBag.TotalPages = (int)Math.Ceiling((decimal)_dbContext.Products.Count() / pageSize);

                return View(await _dbContext.Products.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
            }

            Category category = await _dbContext.Categories.Where(c => c.Slug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            var productsByCategory = _dbContext.Products.Where(p => p.CategoryId == category.Id);
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)productsByCategory.Count() / pageSize);

            return View(await productsByCategory.OrderByDescending(p => p.Id).Skip((p - 1) * pageSize).Take(pageSize).ToListAsync());
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult ViewProduct()
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
                   //Password emcryption
                   string encryptedpass = HashPassword(loginViewModel.Password);
                    var isValid = (data.Username == loginViewModel.Username && data.Password == encryptedpass);
                        if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, loginViewModel.Username)},
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", loginViewModel.Username);
                        TempData["username"] = loginViewModel.Username;
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

        public static string HashPassword(string password)
        {
            var encryptpass = System.Text.Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(encryptpass);
        }

    }
}