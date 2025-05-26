using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        Task<List<GetAllBlogDto>> GetAllBlogDtosAsync();
        Task<List<GetAllBlogDto>> GetAllBlogIsNewDtosAsync();
        Task<GetBlogByIdDto> GetBlogByIdDtoAsync(Guid id);
    }
}
