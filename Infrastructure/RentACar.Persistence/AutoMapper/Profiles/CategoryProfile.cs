using AutoMapper;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, GetAllCategoryQueryResult>();
            CreateMap<Category, GetCategoryByIdQueryResult>();

            CreateMap<GetAllCategoryQueryResult, GetAllCategoryDto>();
            CreateMap<GetCategoryByIdQueryResult, GetCategoryByIdDto>();

            CreateMap<CreateCategoryDto, CreateCategoryCommand>();
            CreateMap<GetCategoryByIdDto, UpdateCategoryDto>();
            CreateMap<UpdateCategoryDto, UpdateCategoryCommand>();
        }
    }
}
