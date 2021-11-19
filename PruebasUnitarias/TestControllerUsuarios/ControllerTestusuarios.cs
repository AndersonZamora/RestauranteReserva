using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using Reservas.Controllers;
using Reservas.Interfaces;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebasUnitarias.TestControladorUsuarios
{
    public class ControllerTestUsuarios
    {
        private Mock<IPersonal> personalRepository;

        [SetUp]
        public void SetUp()
        {
            personalRepository = new Mock<IPersonal>();

        }
        [Test]
        public void TestIndexListaPersonalIsOkCase01()
        {
            personalRepository.Setup(a => a.getLista()).Returns(new List<Personal>());

            var controller = new UsuariosController(personalRepository.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Personal>>(view.Model);
        }

        [Test]
        public void TestCreatePersonalIsOkCase02()
        {
            personalRepository.Setup(a => a.createPersonal(new Personal()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El usuario se ha creado correctamente";

            var controller = new UsuariosController(personalRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Create(new Personal());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditReturnPersonalIsOkCase03()
        {
            personalRepository.Setup(a => a.getPersonal(5)).Returns(new Personal());

            var controller = new UsuariosController(personalRepository.Object);

            var view = controller.Edit(5) as ViewResult;

            Assert.IsInstanceOf<Personal>(view.Model);
        }

        [Test]
        public void TestEditPersonalIsOkCase04()
        {
            personalRepository.Setup(a => a.createPersonal(new Personal()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El usuario se ha editado correctamente";

            var controller = new UsuariosController(personalRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Edit(new Personal());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestDeleteReturnPersonalIsOkCase05()
        {
            personalRepository.Setup(a => a.getPersonal(5)).Returns(new Personal());

            var controller = new UsuariosController(personalRepository.Object);

            var view = controller.Delete(5) as ViewResult;

            Assert.IsInstanceOf<Personal>(view.Model);
        }

        [Test]
        public void TestDeletePersonalIsOkCase06()
        {
            personalRepository.Setup(a => a.deletePersona(5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "El usuario se ha eliminado correctamente";

            var controller = new UsuariosController(personalRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.DeleteMesa(5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}