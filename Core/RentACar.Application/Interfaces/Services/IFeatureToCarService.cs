using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IFeatureToCarService
    {
        Task<IResult> CreateFeatureToCarAsync(CreateFeatureToCarDto createFeatureToCarDto);
        Task<IResult> UpdateFeatureToCarAsync(UpdateFeatureToCarDto updateFeatureToCarDto);
        Task<IResult> DeleteFeatureToCarAsync(Guid id);
        Task<IDataResult<List<GetAllFeatureToCarDto>>> GetAllFeatureToCarsAsync();
        Task<IDataResult<GetFeatureToCarByIdDto>> GetFeatureToCarByIdAsync(Guid id);
    }
}
