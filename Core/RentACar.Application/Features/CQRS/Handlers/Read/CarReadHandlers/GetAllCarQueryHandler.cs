using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IDataResult<List<GetAllCarQueryResult>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<List<GetAllCarQueryResult>>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetAllAsync();
            var result = values.Select(c => new GetAllCarQueryResult
            {
                Id = c.Id,
                BrandId = c.BrandId,
                Model = c.Model,
                Fuel = c.Fuel,
                Km = c.Km,
                Seat = c.Seat,
                Transmission = c.Transmission,
                Luggage = c.Luggage,
                CoverImageUrl = c.CoverImageUrl,
                DetailImageUrl = c.DetailImageUrl
            }).ToList();

            if (result.Count >0)
            {
                return new SuccessDataResult<List<GetAllCarQueryResult>>(result, "Car list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCarQueryResult>>("Car list is empty!");
        }
    }
}
