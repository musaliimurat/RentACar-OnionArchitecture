﻿using AutoMapper;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class BlogMappingProfile : Profile
    {
        public BlogMappingProfile()
        {
            CreateMap<Blog, GetAllBlogDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.AuthorImageUrl, opt => opt.MapFrom(src => src.Author.ImageUrl))
                .ForMember(dest => dest.AuthorDescription, opt => opt.MapFrom(src => src.Author.Description));

            CreateMap<Blog, GetBlogByIdDto>()
                  .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.AuthorImageUrl, opt => opt.MapFrom(src => src.Author.ImageUrl))
                .ForMember(dest => dest.AuthorDescription, opt => opt.MapFrom(src => src.Author.Description));

            CreateMap<Blog, GetAllBlogWithCategoryNameDto>()
              .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateBlogDto, CreateBlogCommand>();
            CreateMap<GetBlogByIdDto, UpdateBlogDto>();
            CreateMap<UpdateBlogDto, UpdateBlogCommand>();
        }
    }
}
