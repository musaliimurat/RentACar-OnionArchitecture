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
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, IResult>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IResult> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetAsync(c => c.Id == request.Id);
            if (value != null)
            {
                value.BrandId = request.BrandId;
                value.Model = request.Model;
                value.Fuel = request.Fuel;
                value.Km = request.Km;
                value.Transmission = request.Transmission;
                value.Luggage = request.Luggage;
                value.Seat = request.Seat;
                value.CoverImageUrl = request.CoverImageUrl;
                value.DetailImageUrl = request.DetailImageUrl;
                value.UpdateDate = DateTime.Today;

                await _carRepository.UpdateAsync(value);
                return new SuccessResult("Car is updated successfully!");
            }
            else return new ErrorResult("Car is not updated!");
        }
    }
}
