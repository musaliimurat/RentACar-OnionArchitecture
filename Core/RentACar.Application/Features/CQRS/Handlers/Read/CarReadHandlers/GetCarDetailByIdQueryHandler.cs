using AutoMapper;
using MediatR;
using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetCarDetailByIdQueryHandler : IRequestHandler<GetCarDetailByIdQuery, IDataResult<GetCarByIdDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetCarDetailByIdQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCarByIdDto>> Handle(GetCarDetailByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetCarDetailByIdReadAsync(request.Id);

            if (value == null) return new ErrorDataResult<GetCarByIdDto>("Car not found!");

            var result = _mapper.Map<GetCarByIdDto>(value);

            return new SuccessDataResult<GetCarByIdDto>(result, "Car load is successfull!");
        }
    }
}
