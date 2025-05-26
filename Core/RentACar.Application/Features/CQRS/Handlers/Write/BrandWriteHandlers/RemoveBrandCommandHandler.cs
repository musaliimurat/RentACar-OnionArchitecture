using MediatR;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BrandWriteHandlers
{
    public class RemoveBrandCommandHandler : IRequestHandler<RemoveBrandCommand, IResult>
    {
        private readonly IBrandRepository _brandRepository;

        public RemoveBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<IResult> Handle(RemoveBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                await _brandRepository.RemoveAsync(value);
                return new SuccessResult("Brand removed successfully!");
            }
            else return new ErrorResult("Brand not found!");
        }
    }
}
