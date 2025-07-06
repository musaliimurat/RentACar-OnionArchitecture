using RentACar.Application.DTOs.Concrete.BrandDto;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IBrandService
    {
        Task<IDataResult<List<GetAllBrandDto>>> GetAllBrandsAsync();
        Task<IDataResult<GetBrandByIdDto>> GetBrandByIdAsync(Guid id);
        Task<IResult> CreateBrandAsync(CreateBrandDto createBrandDto);
        Task<IResult> UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task<IResult> DeleteBrandAsync(Guid id);
    }
}
