using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, IDataResult<GetCarByIdQueryResult>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCarByIdQueryResult>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetAsync(c => c.Id == request.Id);

            if (value == null) return new ErrorDataResult<GetCarByIdQueryResult>("Car not found!");

            var result = _mapper.Map<GetCarByIdQueryResult>(value);

            return new SuccessDataResult<GetCarByIdQueryResult>(result, "Car load is successfull!");
        }
    }
}
