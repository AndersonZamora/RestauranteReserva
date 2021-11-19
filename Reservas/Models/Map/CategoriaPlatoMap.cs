using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Models.Map
{
    public class CategoriaPlatoMap : IEntityTypeConfiguration<CategoriaPlato>
    {
        public void Configure(EntityTypeBuilder<CategoriaPlato> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(o => o.Id);
        }
    }
}
