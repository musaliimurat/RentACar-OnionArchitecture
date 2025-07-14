using AutoMapper;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CarFeatureProfile : Profile
    {
        public CarFeatureProfile()
        {
            CreateMap<FeatureToCar, GetAllCarFeatureQueryResult>()
             .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Car.BrandId))
             .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
             .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
             .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl))
             .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(src => src.Feature.Name));

            CreateMap<FeatureToCar, GetCarFeatureByIdQueryResult>()
             .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Car.BrandId))
             .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
             .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
             .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl))
             .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(src => src.Feature.Name));

            CreateMap<GetAllCarFeatureQueryResult, GetAllFeatureToCarDto>();
            CreateMap<GetCarFeatureByIdQueryResult, GetFeatureToCarByIdDto>();

            CreateMap<CreateFeatureToCarDto, CreateFeatureToCarCommand>();
            CreateMap<GetFeatureToCarByIdDto, UpdateFeatureToCarDto>();
            CreateMap<UpdateFeatureToCarDto, UpdateFeatureToCarCommand>();


        }
    }
}
