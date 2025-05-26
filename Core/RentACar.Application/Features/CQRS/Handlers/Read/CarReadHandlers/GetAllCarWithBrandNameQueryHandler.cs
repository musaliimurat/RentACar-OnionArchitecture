using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetAllCarWithBrandNameQueryHandler : IRequestHandler<GetAllCarWithBrandNameQuery, IDataResult<PaginatedList<GetAllCarsDto>>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarWithBrandNameQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IDataResult<PaginatedList<GetAllCarsDto>>> Handle(GetAllCarWithBrandNameQuery request, CancellationToken cancellationToken)
        {
            var allCars = await _carRepository.GetAllCarsReadAsync();

            var count = allCars.Count;
            var items = allCars
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = new PaginatedList<GetAllCarsDto>
            {
                Items = items,
                TotalCount = count,
                PageSize = request.PageSize,
                CurrentPage = request.Page
            };
            if (result.TotalCount > 0)
            {
                return new SuccessDataResult<PaginatedList<GetAllCarsDto>>(result, "Car list is load successfull!");
            }
            else return new ErrorDataResult<PaginatedList<GetAllCarsDto>>("Car list is empty!");
        }
    }
}
