using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Features.Validators.BrandValidators;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Aspects.ValidationAspect;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BrandWriteHandlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IResult>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Name = request.Name,
            };

            await _brandRepository.CreateAsync(brand);
            return new SuccessResult("Brand added successfully!");
        }
    }
}
