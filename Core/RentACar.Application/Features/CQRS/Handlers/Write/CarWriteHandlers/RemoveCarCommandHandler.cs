using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarWriteHandlers
{
    public class RemoveCarCommandHandler : IRequestHandler<RemoveCarCommand, IResult>
    {
        private readonly ICarRepository _carRepository;

        public RemoveCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

       
        public async Task<IResult> Handle(RemoveCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetAsync(c => c.Id == request.Id);
            if (value != null)
            {

                await _carRepository.RemoveAsync(value);
                return new SuccessResult("Car is removed successfully!");
            }
            else return new ErrorResult("Car is not removed!");
        }
    }
}
