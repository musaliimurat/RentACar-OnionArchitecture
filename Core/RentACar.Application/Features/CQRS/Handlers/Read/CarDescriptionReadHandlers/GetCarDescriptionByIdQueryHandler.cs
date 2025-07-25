using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CarDescriptionQueries;
using RentACar.Application.Features.CQRS.Results.CarDescriptionResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CarDescriptionReadHandlers
{
    public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, IDataResult<GetCarDescriptionByIdQueryResult>>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;
        private readonly IMapper _mapper;

        public GetCarDescriptionByIdQueryHandler(IMapper mapper, ICarDescriptionRepository carDescriptionRepository)
        {
            _mapper = mapper;
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<IDataResult<GetCarDescriptionByIdQueryResult>> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var carDescription = await _carDescriptionRepository.GetCarDescriptionByIdAsync(request.Id);
            var mappedData = _mapper.Map<GetCarDescriptionByIdQueryResult>(carDescription);
            if (mappedData == null)
            {
                return new ErrorDataResult<GetCarDescriptionByIdQueryResult>("No car descriptions found.");
            }
            return new SuccessDataResult<GetCarDescriptionByIdQueryResult>(mappedData, "Car descriptions retrieved successfully.");
        }
    }
}
