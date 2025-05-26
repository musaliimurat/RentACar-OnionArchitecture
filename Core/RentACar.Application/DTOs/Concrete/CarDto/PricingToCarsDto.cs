using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.CarDto
{
    public class PricingToCarsDto : IDto
    {
        public Guid Id { get; set; }
        public string PricingName { get; set; }
        public decimal Amount { get; set; }
    }
}
