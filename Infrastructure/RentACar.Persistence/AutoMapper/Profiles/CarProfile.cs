using AutoMapper;
using RentACar.Application.DTOs.Concrete;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, GetAllCarsDto>()
                  .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                  .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));

            CreateMap<PricingToCar, PricingToCarsDto>()
                .ForMember(dest=>dest.PricingName, opt=> opt.MapFrom(src=>src.Pricing.Name))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Car, GetAllFeaturedCarsDto>()
                .ForMember(dest=>dest.BrandName, opt=>opt.MapFrom(src=>src.Brand.Name))
                .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));

            CreateMap<Car, GetAllCarsToPriceListDto>()
                 .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                 .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));
        }
    }
}
