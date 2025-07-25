using MediatR;
using RentACar.Application.Features.CQRS.Commands.FooterAddressCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.FooterAddressWriteHandlers
{
    public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand, IResult>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public RemoveFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<IResult> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetAsync(f => f.Id == request.Id);
            if (value != null)
            {
                await _footerAddressRepository.RemoveAsync(value);
                return new SuccessResult("Footer Address is removed successfully!");
            }
            else return new ErrorResult("Footer Address is not removed!");
        }
    }
}
