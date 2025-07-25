using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentACar.Application.DTOs.Concrete.BannerDTOs;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class BannerProfile : Profile
    {
        public BannerProfile()
        {
            CreateMap<Banner, GetAllBannerQueryResult>();
            CreateMap<Banner, GetBannerByIdQueryResult>();
            CreateMap<GetAllBannerQueryResult, GetAllBannerDto>();
            CreateMap<GetBannerByIdQueryResult, GetBannerByIdDto>();
            CreateMap<CreateBannerDto, CreateBannerCommand>();
            CreateMap<UpdateBannerDto, UpdateBannerCommand>();
            CreateMap<GetBannerByIdDto, UpdateBannerDto>();
        }
    }
}
