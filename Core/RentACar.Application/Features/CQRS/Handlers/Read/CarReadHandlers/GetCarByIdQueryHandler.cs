using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, IDataResult<GetCarByIdQueryResult>>
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<GetCarByIdQueryResult>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetAsync(c => c.Id == request.Id);
            if (value == null) return new ErrorDataResult<GetCarByIdQueryResult>("Car not found!"); ;
            var result = new GetCarByIdQueryResult
            {
                Id = value.Id,
                BrandId = value.BrandId,
                Model = value.Model,
                Fuel = value.Fuel,
                Km = value.Km,
                Seat = value.Seat,
                Transmission = value.Transmission,
                Luggage = value.Luggage,
                CoverImageUrl = value.CoverImageUrl,
                DetailImageUrl = value.DetailImageUrl
            };

            return new SuccessDataResult<GetCarByIdQueryResult>(result, "Car load is successfull!");
        }
    }
}
