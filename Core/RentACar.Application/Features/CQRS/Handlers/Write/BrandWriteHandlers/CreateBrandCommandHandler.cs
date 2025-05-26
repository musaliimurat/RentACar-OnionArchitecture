using MediatR;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BrandWriteHandlers
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, IResult>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<IResult> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {

            if (request != null)
            {
                Brand brand = new()
                {
                    Name = request.Name,
                };
                await _brandRepository.CreateAsync(brand);
                return new SuccessResult("Brand added successfully!");
            }
            else
            {
                return new ErrorResult("Brand not added!");
            }
        }
    }
}
