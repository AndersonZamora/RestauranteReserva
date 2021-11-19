using Moq;
using NUnit.Framework;
using Reservas.Models;
using Reservas.Models.Map;
using Reservas.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebasUnitarias.TestControladorPersonal
{
    public class ServicioTestPersonal
    {
        private Mock<ReservasDbContext> mockContex;

        [SetUp]
        public void SetUp()
        {
            mockContex = ApplicationMockContext.getListaPersonalContextMock();
        }

        [Test]
        public void testReturnNoNullListaPersonalCaso01()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var mesa = mesaRepository.getLista();

            Assert.IsNotNull(mesa);
        }

        [Test]
        public void testReturnLista3PersonalCaso02()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var mesa = mesaRepository.getLista();

            Assert.AreEqual(3,mesa.Count());
        }

        [Test]
        public void testReturnNullPersonalCaso03()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(null);

            Assert.IsNull(personal);
        }

        [Test]
        public void testReturnPersonalIdCaso04()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(2);

            Assert.AreEqual(2, personal.Id);
        }

        [Test]
        public void testReturnPersonalNombresCaso05()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(1);

            Assert.AreEqual("Personal 1", personal.Nombres);
        }

        [Test]
        public void testReturnPersonalPasswordCaso06()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(2);
            Assert.AreEqual("Password2", personal.Password);
        }

        [Test]
        public void testReturnPersonalRolCaso07()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(3);
            Assert.AreEqual("Rol 3", personal.Rol);
        }

        [Test]
        public void testReturnPersonalUsernameCaso08()
        {
            var mesaRepository = new PersonaService(mockContex.Object);
            var personal = mesaRepository.getPersonal(3);
            Assert.AreEqual("Username 3", personal.Username);
        }
    }
}