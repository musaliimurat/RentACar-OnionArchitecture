using MediatR;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BannerWriteHandlers
{
    public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand, IResult>
    {
        private readonly IBannerRepository _bannerRepository;

        public RemoveBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }


        public async Task<IResult> Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                await _bannerRepository.RemoveAsync(value);
                return new SuccessResult("Banner removed successfully!");
            }
            else return new ErrorResult("Banner not found!");
        }
    }
}
