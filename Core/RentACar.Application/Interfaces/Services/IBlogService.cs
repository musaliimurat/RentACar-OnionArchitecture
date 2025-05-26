using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IBlogService
    {
        Task<IDataResult<PaginatedList<GetAllBlogDto>>> GetAllBlogAsync(int page, int pageSize);
        Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogIsNewAsync();
        Task<IDataResult<GetBlogByIdDto>> GetBlogByIdAsync(Guid id);
        Task<IResult> CreateBlogAsync(CreateBlogCommand command);
        Task<IResult> UpdateBlogAsync(UpdateBlogCommand command);
        Task<IResult> DeleteBlogAsync(Guid id);
    }
}
