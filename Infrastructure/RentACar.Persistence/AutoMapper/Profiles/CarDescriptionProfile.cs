using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;
using RentACar.Application.Features.CQRS.Results.CarDescriptionResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CarDescriptionMappingProfile : Profile
    {
        public CarDescriptionMappingProfile()
        {
            CreateMap<CarDescription, GetAllCarDescriptionQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
                .ForMember(dest => dest.CoverPhotoUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl));

            CreateMap<CarDescription, GetCarDescriptionByIdQueryResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.CarId))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.Name))
                .ForMember(dest => dest.CoverPhotoUrl, opt => opt.MapFrom(src => src.Car.CoverImageUrl));

            CreateMap<CarDescription, GetAllCarDescriptionForCarListDto>();

            CreateMap<GetAllCarDescriptionQueryResult, GetAllCarDescriptionDto>();
            CreateMap<GetCarDescriptionByIdQueryResult, GetCarDescriptionByIdDto>();

            CreateMap<CreateCarDescriptionDto, CreateCarDescriptionCommand>();
            CreateMap<GetCarDescriptionByIdDto, UpdateCarDescriptionDto>();
            CreateMap<UpdateCarDescriptionDto, UpdateCarDescriptionCommand>();
              
        }
    }
}
