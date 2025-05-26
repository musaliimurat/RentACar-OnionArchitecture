using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarPricingCommands
{
    public class UpdatePricingToCarCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid PricingId { get; set; }
        public decimal Amount { get; set; }
    }
}
