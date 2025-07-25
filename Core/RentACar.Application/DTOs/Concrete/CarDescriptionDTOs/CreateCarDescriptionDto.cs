using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CarDescriptionDTOs
{
    public class CreateCarDescriptionDto : IDto
    {
        public Guid CarId { get; set; }
        public string Details { get; set; }
    }

}
