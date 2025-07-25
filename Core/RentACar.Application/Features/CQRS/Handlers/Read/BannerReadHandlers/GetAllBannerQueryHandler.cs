using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BannerReadHandlers
{
    public class GetAllBannerQueryHandler : IRequestHandler<GetAllBannerQuery, IDataResult<List<GetAllBannerQueryResult>>>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;

        public GetAllBannerQueryHandler(IBannerRepository bannerRepository, IMapper mapper)
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }



        public async Task<IDataResult<List<GetAllBannerQueryResult>>> Handle(GetAllBannerQuery request, CancellationToken cancellationToken)
        {
            var values = await _bannerRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllBannerQueryResult>>(values);
            if (result.Count > 0 )
            {
                return new SuccessDataResult<List<GetAllBannerQueryResult>>(result, "Banner list load successfull!");
            }
            else return new ErrorDataResult<List<GetAllBannerQueryResult>>("Banner list is empty!");
        }
    }
}
