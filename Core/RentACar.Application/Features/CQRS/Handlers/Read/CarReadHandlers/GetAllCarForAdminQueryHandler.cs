using AutoMapper;
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
    public class GetAllCarForAdminQueryHandler : IRequestHandler<GetAllCarWithBrandNameForAdminQuery, IDataResult<List<GetAllCarsWithBrandNameForAdminDto>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarForAdminQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllCarsWithBrandNameForAdminDto>>> Handle(GetAllCarWithBrandNameForAdminQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetAllCarsReadForAdminAsync();
            var result = _mapper.Map<List<GetAllCarsWithBrandNameForAdminDto>>(values);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllCarsWithBrandNameForAdminDto>>(result, "Car list is loaded successfully!");
            }
            else
            {
                return new ErrorDataResult<List<GetAllCarsWithBrandNameForAdminDto>>("Car list is empty!");
            }

        }
    }
}
