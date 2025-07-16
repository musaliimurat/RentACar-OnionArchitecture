using RentACar.Application.DTOs.Concrete.AuthorDTOs;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IAuthorService
    {
        Task<IResult> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<IResult> UpdateAuthorAsync(UpdateAuthorDto updateAuthorDto);
        Task<IResult> DeleteAuthorAsync(Guid id);
        Task<IDataResult<GetAuthorByIdDto>> GetAuthorByIdAsync(Guid id);
        Task<IDataResult<List<GetAllAuthorDto>>> GetAllAuthorsAsync();
    }
}
