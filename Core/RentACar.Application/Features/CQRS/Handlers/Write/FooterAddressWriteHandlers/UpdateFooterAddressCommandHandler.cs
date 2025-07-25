using MediatR;
using RentACar.Application.Features.CQRS.Commands.FooterAddressCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FooterAddressWriteHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand, IResult>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public UpdateFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<IResult> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                value.Email = request.Email;
                value.PhoneNumber = request.PhoneNumber;
                value.Address = request.Address;
                value.Description = request.Description;
                value.UpdateDate = DateTime.Today;
                await _footerAddressRepository.UpdateAsync(value);
                return new SuccessResult("Footer Address is updated successfull!");
            }
            else return new ErrorResult("Footer Address not found!");

        }
    }
}
