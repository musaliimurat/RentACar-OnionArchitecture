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
    public class GetAllCarIsSliderQueryHandler : IRequestHandler<GetAllCarIsSliderQuery, IDataResult<List<GetAllCarsSliderDto>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarIsSliderQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<List<GetAllCarsSliderDto>>> Handle(GetAllCarIsSliderQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetAllFeaturedCarsReadAsync();
            if (values.Count > 0)
            {
                return new SuccessDataResult<List<GetAllCarsSliderDto>>(values, "Car list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCarsSliderDto>>("Car list is empty!");
        }
    }
}
