using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasUnitarias.TestCategoriaPlato
{
    public class ServiceTestCategoria
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaCategoriaContextMock();
        }

        [Test]
        public void testReturnListaCategoriasCaso01()
        {
            var categoriaRepository = new CategoriaPlatoService(mockContex.Object);
            var categoria = categoriaRepository.getLista();

            Assert.IsNotNull(categoria);
        }

        [Test]
        public void testReturnLista4CategoriasCaso02()
        {
            var categoriaRepository = new CategoriaPlatoService(mockContex.Object);
            var categoria = categoriaRepository.getLista();
            Assert.AreEqual(4,categoria.Count());
        }

        [Test]
        public void testReturnUnaCategoriaNombreCaso03()
        {
            var categoriaRepository = new CategoriaPlatoService(mockContex.Object);
            var categoria = categoriaRepository.getCategoria(2);

            Assert.AreEqual("Prueba 2", categoria.NombreCategoria);
        }

        [Test]
        public void testReturnUnaCategoriaIdCaso04()
        {
            var categoriaRepository = new CategoriaPlatoService(mockContex.Object);
            var categoria = categoriaRepository.getCategoria(2);

            Assert.AreEqual(2, categoria.Id);
        }

        [Test]
        public void testReturnNullCategoriaCaso05()
        {
            var categoriaRepository = new CategoriaPlatoService(mockContex.Object);
            var categoria = categoriaRepository.getCategoria(null);

            Assert.IsNull(categoria);
        }
    }
}
