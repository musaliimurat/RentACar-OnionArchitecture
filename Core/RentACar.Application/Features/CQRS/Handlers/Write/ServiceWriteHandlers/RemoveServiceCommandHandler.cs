using MediatR;
using RentACar.Application.Features.CQRS.Commands.ServiceCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.ServiceWriteHandlers
{
    public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand, IResult>
    {
        private readonly IServiceRepository _serviceRepository;
        public RemoveServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<IResult> Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(s => s.Id == request.Id);
            if (service == null) return new ErrorResult("Service not found!");
            await _serviceRepository.RemoveAsync(service);
            return new SuccessResult("Service deleted successfully!");
        }
    }
   
}
