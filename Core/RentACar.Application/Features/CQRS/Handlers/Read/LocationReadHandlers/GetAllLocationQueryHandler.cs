using MediatR;
using RentACar.Application.Features.CQRS.Queries.LocationQueries;
using RentACar.Application.Features.CQRS.Results.LocationResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.LocationReadHandlers
{
    public class GetAllLocationQueryHandler : IRequestHandler<GetAllLocationQuery, IDataResult<List<GetAllLocationQueryResult>>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetAllLocationQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IDataResult<List<GetAllLocationQueryResult>>> Handle(GetAllLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetAllAsync();
            var result = values.Select(f => new GetAllLocationQueryResult
            {
                Id = f.Id,
                Name = f.Name,
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllLocationQueryResult>>(result, "Location list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllLocationQueryResult>>("Location list is not found!");
        }
    }
}
