using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetAllCarsToPriceListQueryHandler : IRequestHandler<GetAllCarsToPriceListQuery, IDataResult<List<GetAllCarsToPriceListDto>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsToPriceListQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<List<GetAllCarsToPriceListDto>>> Handle(GetAllCarsToPriceListQuery request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.GetAllCarsToPriceListsReadAsync();
            if (result == null)
            {
                return new ErrorDataResult<List<GetAllCarsToPriceListDto>>("No cars found.");
            }
            else return new SuccessDataResult<List<GetAllCarsToPriceListDto>>(result, "Cars retrieved successfully.");
        }
    }
}
