using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using RentACar.Application.Features.CQRS.Results.PricingResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class PricingMappingProfile : Profile
    {
        public PricingMappingProfile()
        {
            CreateMap<Pricing, GetAllPricingQueryResult>();
            CreateMap<Pricing, GetPricingByIdQueryResult>();

            CreateMap<GetAllPricingQueryResult, GetAllPricingDto>();
            CreateMap<GetPricingByIdQueryResult, GetPricingByIdDto>();

            CreateMap<CreatePricingDto, CreatePricingCommand>();
            CreateMap<UpdatePricingDto, UpdatePricingCommand>();

            CreateMap<GetPricingByIdDto, UpdatePricingDto>();
        }
    }
}
