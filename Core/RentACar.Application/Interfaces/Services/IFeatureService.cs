using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using RentACar.Application.Features.CQRS.Results.FeatureResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IFeatureService
    {
        Task<IResult> CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<IResult> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task<IResult> DeleteFeatureAsync(Guid id);
        Task<IDataResult<List<GetAllFeatureDto>>> GetAllFeaturesAsync();
        Task<IDataResult<GetFeatureByIdDto>> GetFeatureByIdAsync(Guid id);

    }
}
