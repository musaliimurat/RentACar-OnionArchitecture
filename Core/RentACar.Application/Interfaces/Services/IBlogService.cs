using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.DTOs.Concrete.BlogDTOs;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Pagination;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IBlogService
    {
        Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogForAdminAsync();
        Task<IDataResult<PaginatedList<GetAllBlogDto>>> GetAllBlogAsync(int page, int pageSize);
        Task<IDataResult<PaginatedList<GetAllBlogDto>>> GetAllBlogByCategoryAsync(Guid categoryId, int page, int pageSize);
        Task<IDataResult<List<GetAllBlogDto>>> GetAllBlogIsNewAsync();
        Task<IDataResult<List<GetAllBlogWithCategoryNameDto>>> GetAllBlogWithCategoryNameAsync();
        Task<IDataResult<GetBlogByIdDto>> GetBlogByIdAsync(Guid id);
        Task<IResult> CreateBlogAsync(CreateBlogDto createBlogDto);
        Task<IResult> UpdateBlogAsync(UpdateBlogDto updateBlogDto);
        Task<IResult> DeleteBlogAsync(Guid id);
    }
}
