using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class FeatureToCar : BaseEntity
    {
        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public bool IsAvailable { get; set; }
    }
}
