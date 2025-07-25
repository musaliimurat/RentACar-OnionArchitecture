using MediatR;
using RentACar.Application.Features.CQRS.Commands.LocationCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.LocationWriteHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand, IResult>
    {
        private readonly ILocationRepository _locationRepository;

        public RemoveLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IResult> Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                await _locationRepository.RemoveAsync(value);
                return new SuccessResult("Location is removed successfull!");
            }
            else return new ErrorResult("Location is not removed!");
        }
    }
}
