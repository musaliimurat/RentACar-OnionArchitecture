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
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, IResult>
    {
        private readonly IBrandRepository _brandRepository;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
       
        public async Task<IResult> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetAsync(b => b.Id == request.Id);

            if (value != null)
            {
                value.Name = request.Name;
                value.UpdateDate = DateTime.Today;

                await _brandRepository.UpdateAsync(value);
                return new SuccessResult("Brand updated successfully!");
            }
            else return new ErrorResult("Brand not found!");
        }
    }
}
