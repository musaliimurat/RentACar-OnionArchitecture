using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.FeatureDto
{
    public class CreateFeatureDto : IDto
    {
        public string Name { get; set; }
    }
}
