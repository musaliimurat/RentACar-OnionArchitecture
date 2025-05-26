using MediatR;
using RentACar.Application.Features.CQRS.Commands.LocationCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.LocationWriteHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, IResult>
    {
        private readonly ILocationRepository _locationRepository;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IResult> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                value.Name = request.Name;
                await _locationRepository.UpdateAsync(value);
                return new SuccessResult("Location is updated successfull!");
            }
            else return new ErrorResult("Location is not updated!");
        }
    }
}
