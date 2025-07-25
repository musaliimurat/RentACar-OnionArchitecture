using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Features.CQRS.Results.FeatureResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, GetAllFeatureQueryResult>();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
            CreateMap<CreateFeatureDto, CreateFeatureCommand>();
            CreateMap<UpdateFeatureDto, UpdateFeatureCommand>();
            CreateMap<GetAllFeatureQueryResult, GetAllFeatureDto>();
            CreateMap<GetFeatureByIdQueryResult, GetFeatureByIdDto>();
            CreateMap<GetFeatureByIdDto, UpdateFeatureDto>();
        }
    }
}
