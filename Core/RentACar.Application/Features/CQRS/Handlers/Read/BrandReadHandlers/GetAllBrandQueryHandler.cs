using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BrandReadHandlers
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IDataResult<List<GetAllBrandQueryResult>>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllBrandQueryResult>>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            var values = await _brandRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllBrandQueryResult>>(values); 

            if (result.Count>0)
            {
                return new SuccessDataResult<List<GetAllBrandQueryResult>>(result, "Brand list load successfull!");
            }
            else return new ErrorDataResult<List<GetAllBrandQueryResult>>("Brand list is empty!");
        }
    }
}
