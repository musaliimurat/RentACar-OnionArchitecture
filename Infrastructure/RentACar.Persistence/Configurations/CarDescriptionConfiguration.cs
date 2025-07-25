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
    public class CarDescriptionConfiguration : IEntityTypeConfiguration<CarDescription>
    {
        public void Configure(EntityTypeBuilder<CarDescription> builder)
        {
            builder.ToTable("CarDescription");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Details).IsRequired();
            builder.Property(x=>x.CarId).IsRequired();
        }
    }
}
