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
        Task<IDataResult<List<GetAllBrandQueryResult>>> GetAllBrandsAsync();
        Task<IDataResult<GetBrandByIdQueryResult>> GetBrandByIdAsync(Guid id);
        Task<IResult> CreateBrandAsync(CreateBrandCommand command);
        Task<IResult> UpdateBrandAsync(UpdateBrandCommand command);
        Task<IResult> DeleteBrandAsync(Guid id);
    }
}
