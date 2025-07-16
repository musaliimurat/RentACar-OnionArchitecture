using AutoMapper;
using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.AutoMapper.Profiles
{
    public class AuthorMappingProfile : Profile
    {
        public AuthorMappingProfile()
        {
            CreateMap<Author, GetAllAuthorQueryResult>();
            CreateMap<Author, GetAuthorByIdQueryResult>();

            CreateMap<GetAllAuthorQueryResult, GetAllAuthorDto>();
            CreateMap<GetAuthorByIdQueryResult, GetAuthorByIdDto>();

            CreateMap<CreateAuthorDto, CreateAuthorCommand>();
            CreateMap<GetAuthorByIdDto, UpdateAuthorDto>();
            CreateMap<UpdateAuthorDto, UpdateAuthorCommand>();
        }
    }
}
