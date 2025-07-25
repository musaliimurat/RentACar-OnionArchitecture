using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IDataResult<List<GetAllCarQueryResult>>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllCarQueryResult>>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _carRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllCarQueryResult>>(values);

            if (result.Count >0)
            {
                return new SuccessDataResult<List<GetAllCarQueryResult>>(result, "Car list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCarQueryResult>>("Car list is empty!");
        }
    }
}
