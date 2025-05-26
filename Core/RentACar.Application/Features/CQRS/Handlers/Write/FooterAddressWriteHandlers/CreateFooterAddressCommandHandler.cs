using MediatR;
using RentACar.Application.Features.CQRS.Commands.FooterAddressCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FooterAddressWriteHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand, IResult>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public CreateFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<IResult> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            if (request !=null)
            {
                FooterAddress footerAddress = new()
                {
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    Description = request.Description,
                };
                await _footerAddressRepository.CreateAsync(footerAddress);
                return new SuccessResult("Footer Address is created successfull!");
            }
            else
            {
                return new ErrorResult("Footer Address is not created!");
            }
        }
    }
}
