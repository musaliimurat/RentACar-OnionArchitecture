using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
