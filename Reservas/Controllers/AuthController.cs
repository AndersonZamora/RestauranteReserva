using Microsoft.AspNetCore.Mvc;
using Reservas.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Reservas.Controllers
{
    
    public class AuthController : Controller
    {
        protected readonly InterfaceUser Iuser;
        protected readonly InterfaceAuth Iauth;

        public AuthController(InterfaceUser Iuser)
        {
            this.Iuser = Iuser;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            var usuario = Iuser.FindUserByCredentials(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);
                return Redirect("https://localhost:44335/Home/Index"?? Url.Action("Index", "Home"));
            }
            return Redirect("https://localhost:44335/Auth/Login" ?? Url.Action("Login", "Auth"));
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
