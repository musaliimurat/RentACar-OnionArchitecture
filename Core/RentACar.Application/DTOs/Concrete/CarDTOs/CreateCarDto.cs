using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.CarDto
{
    public class CreateCarDto : IDto
    {
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public IFormFile CoverImageUpload { get; set; }
        public IFormFile DetailImageUpload { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? DetailImageUrl { get; set; }
        public decimal Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
    }
}
