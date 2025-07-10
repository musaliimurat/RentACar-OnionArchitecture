using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarFeatureQueries;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarFeatureReadHandlers
{
    public class GetAllFeatureToCarQueryHandler : IRequestHandler<GetAllCarFeatureQuery, IDataResult<List<GetAllCarFeatureQueryResult>>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;
        private readonly IMapper _mapper;

        public GetAllFeatureToCarQueryHandler(ICarFeatureRepository carFeatureRepository, IMapper mapper)
        {
            _carFeatureRepository = carFeatureRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllCarFeatureQueryResult>>> Handle(GetAllCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var result = await _carFeatureRepository.GetAllWithDetailsAsync();
            if (result == null)
            {
                return new ErrorDataResult<List<GetAllCarFeatureQueryResult>>("No car features found.");
            }
            var mappedResult = _mapper.Map<List<GetAllCarFeatureQueryResult>>(result);
            return new SuccessDataResult<List<GetAllCarFeatureQueryResult>>(mappedResult, "Car features retrieved successfully.");
        }
    }
}
