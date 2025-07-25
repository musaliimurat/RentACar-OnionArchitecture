using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BannerReadHandlers
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, IDataResult<GetBannerByIdQueryResult>>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;

        public GetBannerByIdQueryHandler(IBannerRepository bannerRepository, IMapper mapper)
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<GetBannerByIdQueryResult>> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                var result = _mapper.Map<GetBannerByIdQueryResult>(value);
                return new SuccessDataResult<GetBannerByIdQueryResult>(result, "Banner load is successfull!");
            }
            else return new ErrorDataResult<GetBannerByIdQueryResult>("Banner not found!");
        }
    }
}
