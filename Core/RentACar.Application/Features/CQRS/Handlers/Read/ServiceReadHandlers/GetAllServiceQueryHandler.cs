using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.ServiceQueries;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
// Ignore Spelling: CQRS

namespace RentACar.Application.Features.CQRS.Handlers.Read.ServiceReadHandlers
{
    public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, IDataResult<List<GetAllServiceQueryResult>>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetAllServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult<List<GetAllServiceQueryResult>>> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _serviceRepository.GetAllAsync();
            var result = values.Select(s=> new GetAllServiceQueryResult
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                IconUrl = s.IconUrl,
            }).ToList();
            if (result.Count>0) return new SuccessDataResult<List<GetAllServiceQueryResult>>(result, "Service list is load successfully!");
            else return new ErrorDataResult<List<GetAllServiceQueryResult>>("Service list is not found!");

        }
    }
}
