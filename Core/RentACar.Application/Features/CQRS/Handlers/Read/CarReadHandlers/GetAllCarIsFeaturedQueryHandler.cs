using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
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
    public class GetAllCarIsFeaturedQueryHandler : IRequestHandler<GetAllCarIsFeaturedQuery, IDataResult<List<GetAllFeaturedCarsDto>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarIsFeaturedQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<List<GetAllFeaturedCarsDto>>> Handle(GetAllCarIsFeaturedQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetAllFeaturedCarsReadAsync();
            if (values.Count > 0)
            {
                return new SuccessDataResult<List<GetAllFeaturedCarsDto>>(values, "Car list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllFeaturedCarsDto>>("Car list is empty!");
        }
    }
}
