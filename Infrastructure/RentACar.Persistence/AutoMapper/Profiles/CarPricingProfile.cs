using AutoMapper;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CarPricingMappingProfile : Profile
    {
        public CarPricingMappingProfile()
        {
            CreateMap<PricingToCar, GetAllCarPricingForAdminQueryResult>()
             .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Car.BrandId))
             .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
             .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
             .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl))
             .ForMember(dest => dest.PriceName, opt => opt.MapFrom(src => src.Pricing.Name));

            CreateMap<PricingToCar, GetCarPricingByIdForAdminQueryResult>()
             .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Car.BrandId))
             .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
             .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
             .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl))
             .ForMember(dest => dest.PriceName, opt => opt.MapFrom(src => src.Pricing.Name));

            CreateMap<GetAllCarPricingForAdminQueryResult, GetAllPricingToCarDto>();
            CreateMap<GetCarPricingByIdForAdminQueryResult, GetPricingToCarByIdDto>();

            CreateMap<CreatePricingToCarDto, CreatePricingToCarCommand>();
            CreateMap<GetPricingToCarByIdDto, UpdatePricingToCarDto>();
            CreateMap<UpdatePricingToCarDto, UpdatePricingToCarCommand>();
        }
    }
}
