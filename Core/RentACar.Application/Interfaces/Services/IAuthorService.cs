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
        Task<IResult> CreateAuthorAsync(CreateAuthorCommand request);
        Task<IResult> UpdateAuthorAsync(UpdateAuthorCommand request);
        Task<IResult> DeleteAuthorAsync(Guid id);
        Task<IDataResult<GetAuthorByIdQueryResult>> GetAuthorByIdAsync(Guid id);
        Task<IDataResult<List<GetAllAuthorQueryResult>>> GetAllAuthorsAsync();
    }
}
