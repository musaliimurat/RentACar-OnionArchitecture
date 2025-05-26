using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Services
{
    public interface IBannerService
    {
        Task<IDataResult<List<GetAllBannerQueryResult>>> GetAllBannerAsync();
        Task<IDataResult<GetBannerByIdQueryResult>> GetBannerByIdAsync(Guid id);
        Task<IResult> CreateBannerAsync(CreateBannerCommand command);
        Task<IResult> UpdateBannerAsync(UpdateBannerCommand command);
        Task<IResult> DeleteBannerAsync(Guid id);
    }
}
