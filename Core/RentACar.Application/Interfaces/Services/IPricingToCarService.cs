using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.DTOs.Concrete.PricingToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;
using RentACar.Application.Features.CQRS.Results.CarPricingResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IPricingToCarService
    {
        Task<IDataResult<List<GetAllCarPricingQueryResult>>> GetAllAsync();
        Task<IDataResult<List<GetAllPricingToCarDto>>> GetAllForAdminAsync();
        Task<IDataResult<GetCarPricingByIdQueryResult>> GetByIdAsync(Guid id);
        Task<IDataResult<GetPricingToCarByIdDto>> GetByIdForAdminAsync(Guid id);
        Task<IResult> AddAsync(CreatePricingToCarDto createPricingToCarDto);
        Task<IResult> UpdateAsync(UpdatePricingToCarDto updatePricingToCarDto);
        Task<IResult> DeleteAsync(Guid id);
    }
}
