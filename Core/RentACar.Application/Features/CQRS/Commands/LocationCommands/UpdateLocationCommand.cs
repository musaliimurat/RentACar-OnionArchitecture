using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.LocationCommands
{
    public class UpdateLocationCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
