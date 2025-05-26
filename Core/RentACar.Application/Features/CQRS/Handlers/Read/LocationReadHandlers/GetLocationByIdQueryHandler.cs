using MediatR;
using RentACar.Application.Features.CQRS.Queries.LocationQueries;
using RentACar.Application.Features.CQRS.Results.LocationResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.LocationReadHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, IDataResult<GetLocationByIdQueryResult>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IDataResult<GetLocationByIdQueryResult>> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetAsync(l=>l.Id == request.Id);
            if (values == null) return new ErrorDataResult<GetLocationByIdQueryResult>("Location is not found!");
            var result = new GetLocationByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
            };
            return new SuccessDataResult<GetLocationByIdQueryResult>(result, "Location is load successfull!");
        }
    }
}
