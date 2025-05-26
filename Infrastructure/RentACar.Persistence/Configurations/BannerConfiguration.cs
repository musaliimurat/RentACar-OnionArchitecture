using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Configurations
{
    public class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.ToTable("Banners");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Title).HasMaxLength(200).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(x => x.VideoDescription).HasMaxLength(200).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(x => x.VideoUrl).HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(x => x.CreatedDate).HasColumnType("datetime2").IsRequired();
            builder.Property(x => x.UpdateDate).HasColumnType("datetime2");
        }
    }
}
