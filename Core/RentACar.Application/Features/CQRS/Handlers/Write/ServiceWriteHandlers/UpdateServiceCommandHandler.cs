using MediatR;
using RentACar.Application.Features.CQRS.Commands.ServiceCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.ServiceWriteHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, IResult>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IResult> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _serviceRepository.GetAsync(s=>s.Id == request.Id);
            if (service == null) return new ErrorResult("Service not found!");
            service.Title = request.Title;
            service.Description = request.Description;
            service.IconUrl = request.IconUrl;
            await _serviceRepository.UpdateAsync(service);
            return new SuccessResult("Service updated successfully!");
        }
    }
   
}
