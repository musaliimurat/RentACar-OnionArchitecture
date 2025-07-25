
using MediatR;
using RentACar.Application.Features.CQRS.Queries.ServiceQueries;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
// Ignore Spelling: CQRS

namespace RentACar.Application.Features.CQRS.Handlers.Read.ServiceReadHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, IDataResult<GetServiceByIdQueryResult>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IDataResult<GetServiceByIdQueryResult>> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _serviceRepository.GetAsync(x => x.Id == request.Id);
            if (value != null)
            {
                var result = new GetServiceByIdQueryResult
                {
                    Id = value.Id,
                    Title = value.Title,
                    Description = value.Description,
                    IconUrl = value.IconUrl,
                };
                return new SuccessDataResult<GetServiceByIdQueryResult>(result, "Service is load successfully!");
            }
            else return new ErrorDataResult<GetServiceByIdQueryResult>("Service is not found!");
        }
    }
}
