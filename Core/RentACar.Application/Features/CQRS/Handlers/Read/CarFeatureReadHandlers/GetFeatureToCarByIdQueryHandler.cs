using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarFeatureQueries;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarFeatureReadHandlers
{
    public class GetFeatureToCarByIdQueryHandler : IRequestHandler<GetCarFeatureByIdQuery, IDataResult<GetCarFeatureByIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;
        private readonly IMapper _mapper;

        public GetFeatureToCarByIdQueryHandler(ICarFeatureRepository carFeatureRepository, IMapper mapper)
        {
            _carFeatureRepository = carFeatureRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCarFeatureByIdQueryResult>> Handle(GetCarFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _carFeatureRepository.GetWithDetailByIdAsync(request.Id);
            if (result == null)
            {
                return new ErrorDataResult<GetCarFeatureByIdQueryResult>("No car features found.");
            }
            var mappedResult = _mapper.Map<GetCarFeatureByIdQueryResult>(result);
            return new SuccessDataResult<GetCarFeatureByIdQueryResult>(mappedResult, "Car features retrieved successfully.");
        }
    }
}
