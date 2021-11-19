using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using Reservas.Models;
using Reservas.Models.Map;

namespace PruebasUnitarias
{
    public class ApplicationMockContext
    {
        public static Mock<ReservasDbContext> GetAplicationContextMockUser()
        {
            var data = new List<Usuario>
            {
                new Usuario { Id = 1, Password = "Admin1", Username = "Admin1" },
                new Usuario { Id = 2, Password = "Admin2", Username = "Admin2" },
                new Usuario { Id = 3, Password = "Admin3", Username = "Admin3" },
            }.AsQueryable();

            var mokSet = new Mock<DbSet<Usuario>>();
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<ReservasDbContext>(new DbContextOptions<ReservasDbContext>());
            context.Setup(a => a.Usuarios).Returns(mokSet.Object);

            return context;
        }

        public static Mock<ReservasDbContext> getListaContextMock()
        {
            IQueryable<Mesa> mesa = getMesa();

            var mockDbSetMesa = new Mock<DbSet<Mesa>>();
            mockDbSetMesa.As<IQueryable<Mesa>>().Setup(m => m.Provider).Returns(mesa.Provider);
            mockDbSetMesa.As<IQueryable<Mesa>>().Setup(m => m.Expression).Returns(mesa.Expression);
            mockDbSetMesa.As<IQueryable<Mesa>>().Setup(m => m.ElementType).Returns(mesa.ElementType);
            mockDbSetMesa.As<IQueryable<Mesa>>().Setup(m => m.GetEnumerator()).Returns(mesa.GetEnumerator());
            mockDbSetMesa.Setup(m => m.AsQueryable()).Returns(mesa);


            var mockContext = new Mock<ReservasDbContext>(new DbContextOptions<ReservasDbContext>());
            mockContext.Setup(c => c.Mesa).Returns(mockDbSetMesa.Object);

            return mockContext;
        }

        public static IQueryable<Mesa> getMesa()
        {
            return new List<Mesa>
            {
               new Mesa { Id = 1, Descripcion = "Prueba 1", Estado = 2 ,NumeroMesa = "2",NumeroPersonas = 4},
               new Mesa { Id = 2, Descripcion = "Prueba 2", Estado = 3 ,NumeroMesa = "4",NumeroPersonas = 5},
               new Mesa { Id = 3, Descripcion = "Prueba 3", Estado = 1 ,NumeroMesa = "5",NumeroPersonas = 6},
               new Mesa { Id = 4, Descripcion = "Prueba 4", Estado = 1 ,NumeroMesa = "6",NumeroPersonas = 7}

            }.AsQueryable();
        }

        public static Mock<ReservasDbContext> getListaReservaContextMock()
        {
            IQueryable<Reserva> reserva = getReserva();

            var mockDbSetMesa = new Mock<DbSet<Reserva>>();
            mockDbSetMesa.As<IQueryable<Reserva>>().Setup(m => m.Provider).Returns(reserva.Provider);
            mockDbSetMesa.As<IQueryable<Reserva>>().Setup(m => m.Expression).Returns(reserva.Expression);
            mockDbSetMesa.As<IQueryable<Reserva>>().Setup(m => m.ElementType).Returns(reserva.ElementType);
            mockDbSetMesa.As<IQueryable<Reserva>>().Setup(m => m.GetEnumerator()).Returns(reserva.GetEnumerator());
            mockDbSetMesa.Setup(m => m.AsQueryable()).Returns(reserva);


            var mockContext = new Mock<ReservasDbContext>(new DbContextOptions<ReservasDbContext>());
            mockContext.Setup(c => c.Reserva).Returns(mockDbSetMesa.Object);

            return mockContext;
        }

        public static IQueryable<Reserva> getReserva()
        {
            return new List<Reserva>
            {
               new Reserva { Id = 1, NombreCliente="Juan Perez Soza", Celular = "963258741", FechaReserva = DateTime.Now, MesaId = 1, Mesa = new Mesa(){ } },
               new Reserva { Id = 2, NombreCliente="Jose Perez Soza", Celular = "456987412", FechaReserva = DateTime.Now, MesaId = 2, Mesa = new Mesa(){ } },
               new Reserva { Id = 3, NombreCliente="Mario Perez Soza", Celular = "963258745", FechaReserva = DateTime.Now, MesaId = 3, Mesa = new Mesa(){ } },
               new Reserva { Id = 4, NombreCliente="Juan Galvez Soza", Celular = "963258345", FechaReserva = DateTime.Now, MesaId = 4, Mesa = new Mesa(){ } },
               new Reserva { Id = 5, NombreCliente="Nataly Cerquin", Celular = "963258340", FechaReserva = DateTime.Now, MesaId = 7, Mesa = new Mesa(){ } }

            }.AsQueryable();
        }

        public static Mock<ReservasDbContext> getListaPersonalContextMock()
        {
            IQueryable<Personal> mesa = getPersonal();

            var mockDbSetPersonal = new Mock<DbSet<Personal>>();
            mockDbSetPersonal.As<IQueryable<Personal>>().Setup(m => m.Provider).Returns(mesa.Provider);
            mockDbSetPersonal.As<IQueryable<Personal>>().Setup(m => m.Expression).Returns(mesa.Expression);
            mockDbSetPersonal.As<IQueryable<Personal>>().Setup(m => m.ElementType).Returns(mesa.ElementType);
            mockDbSetPersonal.As<IQueryable<Personal>>().Setup(m => m.GetEnumerator()).Returns(mesa.GetEnumerator());
            mockDbSetPersonal.Setup(m => m.AsQueryable()).Returns(mesa);


            var mockContext = new Mock<ReservasDbContext>(new DbContextOptions<ReservasDbContext>());
            mockContext.Setup(c => c.Personal).Returns(mockDbSetPersonal.Object);

            return mockContext;
        }

        private static IQueryable<Personal> getPersonal()
        {
            return new List<Personal>
            {
                new Personal() { Id = 1,Nombres = "Personal 1", Rol = "Rol 1",Password = "Password1",Username = "Username 1"},
                new Personal() { Id = 2,Nombres = "Personal 2", Rol = "Rol 2",Password = "Password2",Username = "Username 2"},
                new Personal() { Id = 3,Nombres = "Personal 3", Rol = "Rol 3",Password = "Password3",Username = "Username 3"}

            }.AsQueryable();
        }

        public static Mock<ReservasDbContext> getListaCategoriaContextMock()
        {
            IQueryable<CategoriaPlato> categoria = getCategoria();

            var mockDbSetCategoria = new Mock<DbSet<CategoriaPlato>>();
            mockDbSetCategoria.As<IQueryable<CategoriaPlato>>().Setup(m => m.Provider).Returns(categoria.Provider);
            mockDbSetCategoria.As<IQueryable<CategoriaPlato>>().Setup(m => m.Expression).Returns(categoria.Expression);
            mockDbSetCategoria.As<IQueryable<CategoriaPlato>>().Setup(m => m.ElementType).Returns(categoria.ElementType);
            mockDbSetCategoria.As<IQueryable<CategoriaPlato>>().Setup(m => m.GetEnumerator()).Returns(categoria.GetEnumerator());
            mockDbSetCategoria.Setup(m => m.AsQueryable()).Returns(categoria);

            var mockContext = new Mock<ReservasDbContext>(new DbContextOptions<ReservasDbContext>());
            mockContext.Setup(c => c.CategoriaPlato).Returns(mockDbSetCategoria.Object);

            return mockContext;
        }

        public static IQueryable<CategoriaPlato> getCategoria()
        {
            return new List<CategoriaPlato>
            {
               new CategoriaPlato { Id = 1, NombreCategoria = "Prueba 1", },
               new CategoriaPlato { Id = 2, NombreCategoria = "Prueba 2", },
               new CategoriaPlato { Id = 3, NombreCategoria = "Prueba 3", },
               new CategoriaPlato { Id = 4, NombreCategoria = "Prueba 4", }

            }.AsQueryable();
        }

    }

}

