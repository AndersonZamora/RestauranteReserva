using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitarias.TestControladorMesa
{
    public class ServicioTestMesa
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaContextMock();
        }

        [Test]
        public void testReturnListaMesasCaso01()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getLista();
            Assert.IsNotNull(mesa);
        }

        [Test]
        public void testReturnLista4MesasCaso02()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getLista();
            Assert.AreEqual(4,mesa.Count());
        }

        [Test]
        public void testReturnMesaIDCaso03()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(2);
            Assert.AreEqual(2, mesa.Id);
        }

        [Test]
        public void testNoReturnMesaIDCaso04()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(null);
            Assert.IsNull(mesa);
        }

        [Test]
        public void testReturnMesaNumeroMesaCaso05()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(3);
            Assert.AreEqual("5",mesa.NumeroMesa);
        }

        [Test]
        public void testReturnMesaDescriptionCaso06()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(4);
            Assert.AreEqual("Prueba 4", mesa.Descripcion);
        }

        [Test]
        public void testReturnMesaEstadoCaso07()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(3);
            Assert.AreEqual(1, mesa.Estado);
        }

        [Test]
        public void testReturnMesaNumeroPersonasCaso08()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            var mesa = mesaRepository.getMesa(1);
            Assert.AreEqual(4, mesa.NumeroPersonas);
        }

        [Test]
        public void testReturnListaMesasCreadaCaso09()
        {
            var mesaRepository = new MesaService(mockContex.Object);
            List<Mesa> mesas = (List<Mesa>) mesaRepository.getMesaById();

            Assert.AreEqual(2, mesas.Count);
        }
    }
}
