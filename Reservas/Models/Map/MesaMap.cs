using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservas.Map
{
    public class MesaMap : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("Mesa");
            builder.HasKey(o => o.Id);
        }
    }
}
