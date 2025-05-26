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
    public class GetAllFeatureQueryHandler : IRequestHandler<GetAllFeatureQuery, IDataResult<List<GetAllFeautureQueryResult>>>
    {
        private readonly IFeatureRepository _featureRepository;

        public GetAllFeatureQueryHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IDataResult<List<GetAllFeautureQueryResult>>> Handle(GetAllFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _featureRepository.GetAllAsync();
            var result = values.Select(f => new GetAllFeautureQueryResult
            {
                Id = f.Id,
                Name = f.Name,
            }).ToList();
            if (result.Count >0)
            {
                return new SuccessDataResult<List<GetAllFeautureQueryResult>>(result, "Feauure list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllFeautureQueryResult>>("Feature list is not found!");
        }
    }
}
