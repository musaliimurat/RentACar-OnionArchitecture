using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IDataResult<List<GetAllCategoryDto>>> GetAllCategoryAsync();
        Task<IDataResult<GetCategoryByIdDto>> GetCategoryByIdAsync(Guid id);
        Task<IResult> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<IResult> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<IResult> DeleteCategoryAsync(Guid id);
    }
}
