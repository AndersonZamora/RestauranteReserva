using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using Reservas.Controllers;
using Reservas.Interface;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestCategoriaPlato
{
    public class ControllerTestCategoria
    {
        private Mock<ICategoria> categoriaRepository;

        [SetUp]
        public void SetUp()
        {
            categoriaRepository = new Mock<ICategoria>();
        }

        [Test]
        public void TestIndexReturnListaCategoriaIsOkCase01()
        {
            categoriaRepository.Setup(a => a.getLista()).Returns(new List<CategoriaPlato>());

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Index() as ViewResult;

            Assert.IsInstanceOf<List<CategoriaPlato>>(view.Model);
        }
        
        [Test]
        public void TestIndexReturnLista4CategoriaIsOkCase02()
        {
            var categoriaPlato = ApplicationMockContext.getCategoria();

            categoriaRepository.Setup(a => a.getLista()).Returns(categoriaPlato);

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Index() as ViewResult;

            IQueryable<CategoriaPlato> model = (IQueryable<CategoriaPlato>) view.Model;

            Assert.AreEqual(4,model.Count());
        }

        [Test]
        public void TestCreateCategoriaIsOkCase03()
        {
            categoriaRepository.Setup(a => a.createCategoriaPlato(new CategoriaPlato()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La categoria se ha creado correctamente";

            var controller = new CategoriasController(categoriaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Create(new CategoriaPlato());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestEditReturnCategoriaIsOkCase04()
        {
            
            categoriaRepository.Setup(a => a.getCategoria(5)).Returns(new CategoriaPlato());

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Edit(5) as ViewResult;

            Assert.IsInstanceOf<CategoriaPlato>(view.Model);
        }

        [Test]
        public void TestEditReturn1CategoriaIsOkCase05()
        {
            var categoria = new CategoriaPlato()
            {
                Id = 5,
                NombreCategoria = "Categoria 1"
            };

            categoriaRepository.Setup(a => a.getCategoria(5)).Returns(categoria);

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Edit(5) as ViewResult;

            CategoriaPlato plato = (CategoriaPlato) view.Model;

            Assert.AreEqual("Categoria 1",plato.NombreCategoria);
        }

        [Test]
        public void TestEditCategoriaIsOkCase06()
        {
            categoriaRepository.Setup(a => a.updateCategoria(new CategoriaPlato()));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La categoria se ha editado correctamente";

            var controller = new CategoriasController(categoriaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.Edit(new CategoriaPlato());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestDeleteReturnCategoriaIsOkCase07()
        {
            categoriaRepository.Setup(a => a.getCategoria(5)).Returns(new CategoriaPlato());

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Delete(5) as ViewResult;

            Assert.IsInstanceOf<CategoriaPlato>(view.Model);
        }

        [Test]
        public void TestDeleteReturnCategoria1IsOkCase08()
        {
            var categoria = new CategoriaPlato()
            {
                Id = 2,
                NombreCategoria = "Categoria 3"
            };

            categoriaRepository.Setup(a => a.getCategoria(2)).Returns(categoria);

            var controller = new CategoriasController(categoriaRepository.Object);

            var view = controller.Delete(2) as ViewResult;

            CategoriaPlato plato = (CategoriaPlato) view.Model;

            Assert.AreEqual("Categoria 3", plato.NombreCategoria);
        }

        [Test]
        public void TestDeleteCategoriaIsOkCase09()
        {
            categoriaRepository.Setup(a => a.deleteCategoria(5));

            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());

            tempData["mensaje"] = "La categoria se ha eliminado correctamente";

            var controller = new CategoriasController(categoriaRepository.Object)
            {
                TempData = tempData
            };

            var view = controller.DeleteCategoria(5);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
