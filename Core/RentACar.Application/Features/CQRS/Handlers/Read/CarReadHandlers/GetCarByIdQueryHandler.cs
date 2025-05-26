using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
        {
            var value = await _carRepository.GetAsync(c=>c.Id == getCarByIdQuery.Id);
            if (value == null) return null;
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

            return result;
        }
    }
}
