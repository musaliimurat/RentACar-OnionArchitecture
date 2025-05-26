using MediatR;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CarWriteHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, IResult>
    {
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IResult> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = new()
            {
                BrandId = request.BrandId,
                Model = request.Model,
                Fuel = request.Fuel,
                Km = request.Km,
                Luggage = request.Luggage,
                Seat = request.Seat,
                Transmission = request.Transmission,
                CoverImageUrl = request.CoverImageUrl,
                DetailImageUrl = request.DetailImageUrl,

            };
            if (request !=null)
            {
                await _carRepository.CreateAsync(car);
                return new SuccessResult("Car is created successfully!");
            }
            else return new ErrorResult("Car is not created!");
        }
    }
}
