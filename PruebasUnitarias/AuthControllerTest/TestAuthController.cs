using NUnit.Framework;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Reservas.Controllers;
using Reservas.Interface;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;

namespace PruebasUnitarias.AuthControllerTest
{
    public class TestAuthController
    {
        
        [Test]
        public void LoginPasaTest01()
        {
            var authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock
                .Setup(_ => _.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.FromResult((object)null));

            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock
                .Setup(_ => _.GetService(typeof(IAuthenticationService)))
                .Returns(authServiceMock.Object);


            var mock = new Mock<InterfaceUser>();
            mock.Setup(p => p.FindUserByCredentials("Admin1", "Admin1")).Returns(new Usuario { Id = 1, Password = "Admin1", Username = "Admin1" });
            var authMock = new Mock<InterfaceAuth>();

           
            var controller = new AuthController(mock.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        // How mock RequestServices?
                        RequestServices = serviceProviderMock.Object
                    }
                }
            };

            var result = controller.Login("Admin1", "Admin1");
            Assert.IsInstanceOf<RedirectResult>(result);
        }

        [Test]
        public void LoginNoPasaTest02()
        {
            var mock = new Mock<InterfaceUser>();
            mock.Setup(p => p.FindUserByCredentials("admin", "admin")).Returns((Usuario)null);
            var authMock = new Mock<InterfaceAuth>();

            var controller = new AuthController(mock.Object);

            var result = controller.Login("admin", "1234");
            Assert.IsInstanceOf<RedirectResult>(result);
        }
    }
}
