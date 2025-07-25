using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.LocationCommands
{
    public class RemoveLocationCommand(Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
