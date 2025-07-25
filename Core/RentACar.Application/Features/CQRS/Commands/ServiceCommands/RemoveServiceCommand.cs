using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.ServiceCommands
{
    public class RemoveServiceCommand(Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
