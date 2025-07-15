using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    public class RemoveCarDescriptionCommand(Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
