using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitarias.TestControladorReserva
{
    public class ServicioTestReserva
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaReservaContextMock();
        }

        [Test]
        public void testReturnLista5ReservasCaso01()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            var reserva = reservaRepository.getLista();
            Assert.AreEqual(5,reserva.Count());
        }

        [Test]
        public void testReturnListaReservasCaso02()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            var reserva = reservaRepository.getLista();
            Assert.IsNotNull(reserva);
        }

        [Test]
        public void testReturnListaBusquedaCriterioCaso03()
        {
            var reservaRepository = new ReservaService(mockContex.Object);

            var reservas = reservaRepository.getLista("Juan");

            Assert.IsNotNull(reservas);
        }

        [Test]
        public void testReturnListaBusqueda2CriterioCaso04()
        {
            var reservaRepository = new ReservaService(mockContex.Object);

            var reservas = reservaRepository.getLista("Perez");

            Assert.AreEqual(3,reservas.Count());
        }

        [Test]
        public void testReturnListaBusqueda5CriterioCaso05()
        {
            var reservaRepository = new ReservaService(mockContex.Object);

            var reservas = reservaRepository.getLista(null);

            Assert.AreEqual(5, reservas.Count());
        }

        [Test]
        public void testReturnReservaNombreClienteCaso06()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            Reserva reserva = (Reserva) reservaRepository.getReserva(2);

            Assert.AreEqual("Jose Perez Soza", reserva.NombreCliente);
        }

        [Test]
        public void testReturnReservaNumeroClienteCaso07()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            Reserva reserva = (Reserva)reservaRepository.getReserva(3);

            Assert.AreEqual("963258745", reserva.Celular);
        }

        [Test]
        public void testReturnReservaIDCaso08()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            Reserva reserva = (Reserva)reservaRepository.getReserva(4);

            Assert.AreEqual(4, reserva.Id);
        }

        [Test]
        public void testReturnReservaMesaIdDCaso09()
        {
            var reservaRepository = new ReservaService(mockContex.Object);
            Reserva reserva = (Reserva)reservaRepository.getReserva(5);

            Assert.AreEqual(7, reserva.MesaId);
        }
    }
}
