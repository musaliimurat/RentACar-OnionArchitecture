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
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, IDataResult<GetFeatureByIdQueryResult>>
    {
        private readonly IFeatureRepository _featureRepository;

        public GetFeatureByIdQueryHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<IDataResult<GetFeatureByIdQueryResult>> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetAsync(f => f.Id == request.Id);
                
            if (value !=null)
            {
                GetFeatureByIdQueryResult getFeatureByIdQueryResult = new()
                {
                    Id = value.Id,
                    Name = value.Name,
                };
                return new SuccessDataResult<GetFeatureByIdQueryResult>(getFeatureByIdQueryResult, "Feature is load successfull!");
            }
            else return new ErrorDataResult<GetFeatureByIdQueryResult>("Feature is not found!");
        }
    }
}
