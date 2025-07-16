using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.CaregoryDTOs
{
    public class CreateCategoryDto : IDto
    {
        public string Name { get; set; }
    }


}
