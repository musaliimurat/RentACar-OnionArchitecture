using AutoMapper;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, GetAllCarQueryResult>();
            CreateMap<Car, GetCarByIdQueryResult>();

            CreateMap<GetAllCarQueryResult, GetAllCarsDto>();
            CreateMap<GetCarByIdQueryResult, GetCarByIdDto>();
            CreateMap<GetCarByIdDto, UpdateCarDto>();

            CreateMap<CreateCarDto, CreateCarCommand>();
            CreateMap<UpdateCarDto, UpdateCarCommand>();

            CreateMap<Car, GetAllCarsWithBrandNameForAdminDto>()
                  .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                  .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));

            CreateMap<Car, GetAllCarsWithBrandNameDto>()
                  .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                  .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));

            CreateMap<PricingToCar, PricingToCarsDto>()
                .ForMember(dest => dest.PricingName, opt => opt.MapFrom(src => src.Pricing.Name))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));

            CreateMap<Car, GetAllFeaturedCarsDto>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));

            CreateMap<Car, GetAllCarsToPriceListDto>()
                 .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
                 .ForMember(dest => dest.Pricings, opt => opt.MapFrom(src => src.PricingToCars));
        }
    }
}
