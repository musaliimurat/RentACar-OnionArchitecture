using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(150).HasColumnType("nvarchar(150)");
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x=>x.CreatedDate).IsRequired().HasColumnType("datetime2");
        }
    }
}
