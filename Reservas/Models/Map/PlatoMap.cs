using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models.Map
{
    public class PlatoMap : IEntityTypeConfiguration<Plato>
    {
        public void Configure(EntityTypeBuilder<Plato> builder)
        {
            builder.ToTable("Plato");
            builder.HasKey(o => o.Id);
            builder.HasOne(o => o.CategoriaPlato)
                .WithMany()
                .HasForeignKey(o => o.CategoriaId);
        }
    }
}
