using Final_Project1.Entities;
using Final_Project1.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Final_Project1.Areas.admin.Controllers
{
        [Area("admin"), Authorize]
        public class HomeController : Controller
        {
            IRepository<Admin> repoAdmin;
            public HomeController(IRepository<Admin> _repoAdmin)
            {
                repoAdmin = _repoAdmin;
            }


            public IActionResult Index()
            {
                return View();
            }


            [AllowAnonymous, Route("/admin/login")]
            public IActionResult Login(string ReturnUrl)
            {

                ViewBag.ReturnUrl = ReturnUrl;
                return View();
            }

            [AllowAnonymous, Route("/admin/login"), ValidateAntiForgeryToken]
            [HttpPost]
            public async Task<IActionResult> Login(string username, string password, string returnurl)
            {

                var admin = repoAdmin.GetBy(x => x.UserName == username);
                if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.Password))
                {
                    List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.PrimarySid, admin.Id.ToString()),
                    new Claim(ClaimTypes.Name,admin.FullName)
                };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "AdminAuth");

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                           new ClaimsPrincipal(claimsIdentity),
                           new AuthenticationProperties()
                           {
                               IsPersistent = true,
                              
                           });
                    return Redirect("/admin");

                }
                else
                {
                    ViewBag.info = "Kullanıcı Adı veya Şifre Hatalı";
                    return View();
                }


            }

            [Route("/admin/logout")]
            public async Task<IActionResult> LogOut()
            {
                await HttpContext.SignOutAsync();

                return Redirect("/admin/login");
            }
        }
}
