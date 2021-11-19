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
using System.Linq;
using System.Text;

namespace PruebasUnitarias.TestControladorReserva
{
    public class controllerTestReserva
    {
        private Mock<IReserva> reservaRepository;
        private Mock<IMesa> mesaRepository;

        [SetUp]
        public void SetUp()
        {
            reservaRepository = new Mock<IReserva>();
            mesaRepository = new Mock<IMesa>();
        }

        [Test]
        public void TestIndexListaReservasIsOkCase01()
        {

            reservaRepository.Setup(a => a.getLista("")).Returns(new List<Reserva>());

            var controller = new ReservaController(reservaRepository.Object, null);

            var view = controller.Index("") as ViewResult;

            Assert.IsInstanceOf<List<Reserva>>(view.Model);
        }

        [Test]
        public void TestIndexLista5ReservasIsOkCase01()
        {
            var reserva = ApplicationMockContext.getReserva();

            reservaRepository.Setup(a => a.getLista("")).Returns(reserva);

            var controller = new ReservaController(reservaRepository.Object, null);

            var view = controller.Index("") as ViewResult;

            IQueryable<Reserva> model = (IQueryable<Reserva>) view.Model;

            Assert.AreEqual(5, model.Count());
        }

        [Test]
        public void TestCreateReturnReservaIsOkCase02()
        {
            var a = new List<Mesa>()
            {
                new()
                {
                    Id = 1,
                    Descripcion = "Prueba",
                    Estado = 2,
                    NumeroMesa = "22",
                    NumeroPersonas = 4
                },
                new()
                {
                    Id = 1,
                    Descripcion = "Prueba 2",
                    Estado = 2,
                    NumeroMesa = "23",
                    NumeroPersonas = 5
                }
            };

            mesaRepository.Setup(a => a.getMesaByState()).Returns(a);

            var controller = new ReservaController(null, mesaRepository.Object);

            var mesa = controller.ViewBag.Mesa;
            
            Assert.AreEqual(a, mesa);
            
        }

        [Test]
        public void TestCreateReservaIsOkCase03()
        {
            reservaRepository.Setup(a => a.createReserva(new Reserva()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La reserva se ha creado correctamente";

            var controller = new ReservaController(reservaRepository.Object,null)
            {
                TempData = tempData
            };
              
            var view = controller.Create(new Reserva());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditReturnReservaIsOkCase04()
        {
            var a = new List<Mesa>()
            {
                new()
                {
                    Id = 1,
                    Descripcion = "Prueba",
                    Estado = 2,
                    NumeroMesa = "22",
                    NumeroPersonas = 4
                },
                new()
                {
                    Id = 1,
                    Descripcion = "Prueba 2",
                    Estado = 2,
                    NumeroMesa = "23",
                    NumeroPersonas = 5
                }
            };
            
            reservaRepository.Setup(r => r.getReserva(5)).Returns(new Reserva());
            mesaRepository.Setup(a => a.getMesaByState()).Returns(a);

            var controller = new ReservaController(reservaRepository.Object, mesaRepository.Object);

            var view = controller.Edit(5) as ViewResult;
            var mesa = controller.ViewBag.Mesa;

            Assert.IsInstanceOf<Reserva>(view.Model);
            Assert.AreEqual(a, mesa);

        }

        [Test]
        public void TestEditReservaIsOkCase05()
        {
            reservaRepository.Setup(a => a.updateReserva(new Reserva(),5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La reserva se ha editado correctamente";

            var controller = new ReservaController(reservaRepository.Object, null)
            {
                TempData = tempData
            };

            var view = controller.Edit(new Reserva(),5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestDeleteReturnReservaIsOkCase06()
        {
            reservaRepository.Setup(a => a.getReserva(5)).Returns(new Reserva());

            var controller = new ReservaController(reservaRepository.Object,null);

            var view = controller.Delete(5) as ViewResult;

            Assert.IsInstanceOf<Reserva>(view.Model);
        }

        [Test]
        public void TestDeleteReservaIsOkCase07()
        {
            reservaRepository.Setup(a => a.deleteReserva(5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La reserva se ha eliminado correctamente";

            var controller = new ReservaController(reservaRepository.Object,null)
            {
                TempData = tempData
            };

            var view = controller.DeleteReserva(5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

    }
}
