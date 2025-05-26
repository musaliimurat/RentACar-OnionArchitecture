using MediatR;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BannerReadHandlers
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, IDataResult<GetBannerByIdQueryResult>>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannerByIdQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }


        public async Task<IDataResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                var result = new GetBannerByIdQueryResult()
                {
                    Id = value.Id,
                    Title = value.Title,
                    Description = value.Description,
                    VideoDescription = value.VideoDescription,
                    VideoUrl = value.VideoUrl
                };
                return new SuccessDataResult<GetBannerByIdQueryResult>(result, "Banner load is successfull!");
            }
            else return new ErrorDataResult<GetBannerByIdQueryResult>("Banner not found!");
        }
    }
}
