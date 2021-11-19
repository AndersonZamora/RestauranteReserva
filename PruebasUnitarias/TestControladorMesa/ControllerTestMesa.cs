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

namespace PruebasUnitarias.TestControladorMesa
{
    public class ControllerTestMesa
    {
        private Mock<IMesa> mesaRepository;

        [SetUp]
        public void SetUp()
        {
            mesaRepository = new Mock<IMesa>();
        }

        [Test]
        public void TestIndexListaMesasIsOkCase01()
        {
            mesaRepository.Setup(a => a.getLista()).Returns(new List<Mesa>());

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<Mesa>>(view.Model);
        }

        [Test]
        public void TestIndexReturnListaMesas4IsOkCase02()
        {
            var mesa = ApplicationMockContext.getMesa();

            mesaRepository.Setup(a => a.getLista()).Returns(mesa);

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Index() as ViewResult;

            IQueryable<Mesa> mesas = (IQueryable<Mesa>)view.Model;

            Assert.AreEqual(4, mesas.Count());
        }

        [Test]
        public void TestCreateMesaIsOkCase03()
        {
            mesaRepository.Setup(a => a.createMesa(new Mesa()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
        
            tempData["mensaje"] = "La mesa se ha creado correctamente";

            var controller = new MesasController(mesaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Create(new Mesa());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditReturnMesaIsOkCase04()
        {
            mesaRepository.Setup(a => a.getMesa(5)).Returns(new Mesa());

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Edit(5) as ViewResult;

            Assert.IsInstanceOf<Mesa>(view.Model);
        }

        [Test]
        public void TestEditReturnMesaAtributosIsOkCase05()
        {
            var mes = new Mesa { Id = 1, Descripcion = "Prueba 1", Estado = 2, NumeroMesa = "2", NumeroPersonas = 4 };

            mesaRepository.Setup(a => a.getMesa(1)).Returns(mes);

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Edit(1) as ViewResult;

            Mesa mesa = (Mesa) view.Model;

            Assert.AreEqual(1, mesa.Id);
            Assert.AreEqual("Prueba 1", mesa.Descripcion);
            Assert.AreEqual(2, mesa.Estado);
            Assert.AreEqual("2", mesa.NumeroMesa);
            Assert.AreEqual(4, mesa.NumeroPersonas);
        }
        [Test]
        public void TestEditMesaIsOkCase06()
        {
            mesaRepository.Setup(a => a.createMesa(new Mesa()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La mesa se ha editado correctamente";

            var controller = new MesasController(mesaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Edit(new Mesa());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestDeleteReturnMesaIsOkCase07()
        {
            mesaRepository.Setup(a => a.getMesa(5)).Returns(new Mesa());

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Delete(5) as ViewResult;

            Assert.IsInstanceOf<Mesa>(view.Model);
        }

        [Test]
        public void TestDeleteReturnMesaAtributosIsOkCase08()
        {
            var mes = new Mesa { Id = 3, Descripcion = "Prueba 3", Estado = 1, NumeroMesa = "4", NumeroPersonas = 6 };

            mesaRepository.Setup(a => a.getMesa(3)).Returns(mes);

            var controller = new MesasController(mesaRepository.Object);

            var view = controller.Delete(3) as ViewResult;

            Mesa mesa = (Mesa) view.Model;

            Assert.AreEqual(3, mesa.Id);
            Assert.AreEqual("Prueba 3", mesa.Descripcion);
            Assert.AreEqual(1, mesa.Estado);
            Assert.AreEqual("4", mesa.NumeroMesa);
            Assert.AreEqual(6, mesa.NumeroPersonas);
        }

        [Test]
        public void TestDeleteMesaIsOkCase09()
        {
            mesaRepository.Setup(a => a.deleteMesa(5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La mesa se ha eliminado correctamente";

            var controller = new MesasController(mesaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.DeleteMesa(5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
