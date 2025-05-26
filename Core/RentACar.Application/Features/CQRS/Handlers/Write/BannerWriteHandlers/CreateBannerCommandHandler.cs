using MediatR;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BannerWriteHandlers
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, IResult>
    {
        private readonly IBannerRepository _bannerRepository;

        public CreateBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            Banner banner = new()
            {
                Title = request.Title,
                Description = request.Description,
                VideoDescription = request.VideoDescription,
                VideoUrl = request.VideoUrl,
            };
            if (request != null)
            {
                await _bannerRepository.CreateAsync(banner);

                return new SuccessResult("Banner added successfull!");

            }
            else
            {
                return new ErrorResult("Banner not added!");
            }
        }
    }
}
