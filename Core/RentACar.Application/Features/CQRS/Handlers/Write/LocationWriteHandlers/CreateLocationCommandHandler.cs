using MediatR;
using RentACar.Application.Features.CQRS.Commands.LocationCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.LocationWriteHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, IResult>
    {
        private readonly ILocationRepository _locationRepository;

        public CreateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IResult> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return new ErrorResult("Location add error!");

            Location location = new()
            {
                Name = request.Name,
            };
            await _locationRepository.CreateAsync(location);
            return new SuccessResult("Location added successfully!");
        }
    }
}
