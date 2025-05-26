using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IPricingToCarService
    {
        Task<IDataResult<List<GetAllCarPricingQueryResult>>> GetAllAsync();
        Task<IDataResult<GetCarPricingByIdQueryResult>> GetByIdAsync(Guid id);
        Task<IResult> AddAsync(CreatePricingToCarCommand command);
        Task<IResult> UpdateAsync(UpdatePricingToCarCommand command);
        Task<IResult> DeleteAsync(Guid id);
    }
}
