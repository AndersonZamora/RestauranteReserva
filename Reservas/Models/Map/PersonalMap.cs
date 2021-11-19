using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reservas.Models.Map
{
    public class PersonalMap : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.ToTable("Personal");
            builder.HasKey(o => o.Id);
        }
    }
}