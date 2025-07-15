using RentACar.Application.DTOs.Concrete.PricingDTOs;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IPricingService
    {
        Task<IDataResult<List<GetAllPricingDto>>> GetAllPricingAsync();
        Task<IDataResult<GetPricingByIdDto>> GetPricingByIdAsync(Guid id);
        Task<IResult> CreatePricingAsync(CreatePricingDto createPricingDto);
        Task<IResult> UpdatePricingAsync(UpdatePricingDto updatePricingDto);
        Task<IResult> DeletePricingAsync(Guid id);
    }
}
