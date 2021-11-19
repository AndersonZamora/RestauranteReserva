using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Map
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.Mesa)
                .WithMany()
                .HasForeignKey(o => o.MesaId);
        }
    }

}
