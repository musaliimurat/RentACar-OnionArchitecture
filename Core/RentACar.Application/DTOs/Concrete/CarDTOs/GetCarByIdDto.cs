using RentACar.Application.DTOs.Abstract;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.CarDto
{
    public class GetCarByIdDto : IDto
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string DetailImageUrl { get; set; }
        public decimal Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public List<PricingToCarsDto> Pricings { get; set; }
        public List<GetAllFeatureToCarForCarListDto> Features { get; set; }
        public List<GetAllCarDescriptionForCarListDto> CarDescriptions { get; set; }
    }
}
