using Microsoft.AspNetCore.Http;
using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.CarDto
{
    public class CreateCarDto : IDto
    {
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public IFormFile CoverImageUrl { get; set; }
        public IFormFile DetailImageUrl { get; set; }
        public decimal Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
    }
}
