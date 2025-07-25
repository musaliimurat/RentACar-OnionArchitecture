using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.BannerDTOs;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IBannerService
    {
        Task<IDataResult<List<GetAllBannerDto>>> GetAllBannerAsync();
        Task<IDataResult<GetBannerByIdDto>> GetBannerByIdAsync(Guid id);
        Task<IResult> CreateBannerAsync(CreateBannerDto createBannerDto);
        Task<IResult> UpdateBannerAsync(UpdateBannerDto updateBannerDto);
        Task<IResult> DeleteBannerAsync(Guid id);
    }
}
