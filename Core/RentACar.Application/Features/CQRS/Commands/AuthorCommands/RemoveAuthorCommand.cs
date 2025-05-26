using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.AuthorCommands
{
    public class RemoveAuthorCommand (Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
