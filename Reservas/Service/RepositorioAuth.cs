using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Reservas.Interface;

namespace Reservas.Service
{
    public class RepositorioAuth : InterfaceAuth
    {
        public static HttpContext httpContext = new HttpContextAccessor().HttpContext;
        //  HttpContextAccessor().HttpContext;
        // HttpSessionState Session = HttpContext.Current.Session;
        public void Login(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            httpContext.SignInAsync(claimsPrincipal);
        }


        public void Login(ClaimsPrincipal claimsPrincipal)
        {
            httpContext.SignInAsync(claimsPrincipal);
        }

        public void Logout()
        {
            httpContext.SignOutAsync();
        }

        public Claim LoggedUser()
        {
            return httpContext.User.Claims.FirstOrDefault();
        }
    }
}
