using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.FeatureQueries;
using RentACar.Application.Features.CQRS.Results.FeatureResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.FeatureReadHandlers
{
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQuery, IDataResult<List<GetAllFeatureQueryResult>>>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMapper _mapper;

        public GetAllFeatureQueryHandler(IFeatureRepository featureRepository, IMapper mapper)
        {
            _featureRepository = featureRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllFeatureQueryResult>>> Handle(GetAllFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _featureRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllFeatureQueryResult>>(values);

            if (result.Count >0)
            {
                return new SuccessDataResult<List<GetAllFeatureQueryResult>>(result, "Feature list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllFeatureQueryResult>>("Feature list is not found!");
        }
    }
}
