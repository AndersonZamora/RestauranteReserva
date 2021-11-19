using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservas.Models.Map.MapUsuario;
using Reservas.Map;

namespace Reservas.Models.Map
{
    public class ReservasDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Mesa> Mesa { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Plato> Plato { get; set; }
        public virtual DbSet<CategoriaPlato> CategoriaPlato { get; set; }

        public ReservasDbContext(DbContextOptions<ReservasDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new MesaMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new PersonalMap());
            modelBuilder.ApplyConfiguration(new PlatoMap());
            modelBuilder.ApplyConfiguration(new CategoriaPlatoMap());
        }
    }
}
