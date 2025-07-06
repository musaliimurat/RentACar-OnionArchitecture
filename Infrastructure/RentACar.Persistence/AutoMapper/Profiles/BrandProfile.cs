using AutoMapper;
using RentACar.Application.DTOs.Concrete.BrandDto;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, GetAllBrandQueryResult>();
            CreateMap<Brand, GetBrandByIdQueryResult>();
            CreateMap<GetAllBrandQueryResult, GetAllBrandDto>();
            CreateMap<GetBrandByIdQueryResult, GetBrandByIdDto>();
            CreateMap<CreateBrandDto, CreateBrandCommand>();
            CreateMap<UpdateBrandDto, UpdateBrandCommand>();
            CreateMap<GetBrandByIdDto, UpdateBrandDto>();
        }
    }
}
