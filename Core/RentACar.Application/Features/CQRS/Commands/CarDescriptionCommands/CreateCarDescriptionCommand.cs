using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class CreateCarDescriptionCommand : IRequest<IResult>
    {
        public Guid CarId { get; set; }
        public string Details { get; set; }
    }
}
