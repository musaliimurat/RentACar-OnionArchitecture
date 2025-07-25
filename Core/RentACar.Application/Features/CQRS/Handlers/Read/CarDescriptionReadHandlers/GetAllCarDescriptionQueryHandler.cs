using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarDescriptionQueries;
using RentACar.Application.Features.CQRS.Results.CarDescriptionResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarDescriptionReadHandlers
{
    public class GetAllCarDescriptionQueryHandler : IRequestHandler<GetAllCarDescriptionQuery, IDataResult<List<GetAllCarDescriptionQueryResult>>>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;
        private readonly IMapper _mapper;

        public GetAllCarDescriptionQueryHandler(IMapper mapper, ICarDescriptionRepository carDescriptionRepository)
        {
            _mapper = mapper;
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<IDataResult<List<GetAllCarDescriptionQueryResult>>> Handle(GetAllCarDescriptionQuery request, CancellationToken cancellationToken)
        {
            var carDescriptionList = await _carDescriptionRepository.GetAllCarDescriptionsAsync();
            var mappedData = _mapper.Map<List<GetAllCarDescriptionQueryResult>>(carDescriptionList);
            if (mappedData == null || mappedData.Count == 0)
            {
                return new ErrorDataResult<List<GetAllCarDescriptionQueryResult>>("No car descriptions found.");
            }
            return new SuccessDataResult<List<GetAllCarDescriptionQueryResult>>(mappedData, "Car descriptions retrieved successfully.");
        }
    }
}
