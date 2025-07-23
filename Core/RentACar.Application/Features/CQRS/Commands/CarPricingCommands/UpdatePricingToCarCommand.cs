using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;

namespace RentACar.Application.Features.CQRS.Commands.CarPricingCommands
{
    [WithValidation]
    public class UpdatePricingToCarCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
