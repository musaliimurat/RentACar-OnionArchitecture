using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class CarDescription : BaseEntity
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public string Details { get; set; }
    }
}
