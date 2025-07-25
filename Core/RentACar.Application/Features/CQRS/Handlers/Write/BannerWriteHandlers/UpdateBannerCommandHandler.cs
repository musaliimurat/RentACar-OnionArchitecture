using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BannerWriteHandlers
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, IResult>
    {
        private readonly IBannerRepository _bannerRepository;

        public UpdateBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IResult> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetAsync(b => b.Id == request.Id);

            if (value != null)
            {
                value.Title = request.Title;
                value.Description = request.Description;
                value.VideoDescription = request.VideoDescription;
                value.VideoUrl = request.VideoUrl;
                value.UpdateDate = DateTime.Today;

                await _bannerRepository.UpdateAsync(value);
                return new SuccessResult("Banner updated successfully!");
            }
            else return new ErrorResult("Banner not found!");
        }
    }
}
