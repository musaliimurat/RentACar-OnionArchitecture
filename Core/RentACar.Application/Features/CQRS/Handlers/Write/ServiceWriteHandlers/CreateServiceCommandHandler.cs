using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.ServiceCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.ServiceWriteHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, IResult>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IResult> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return new ErrorResult("Service add error!");
            Service service = new()
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl,
            };
            await _serviceRepository.CreateAsync(service);
            return new SuccessResult("Service added successfully!");
        }
    }
   
}
