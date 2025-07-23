using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;

namespace RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    [WithValidation]
    public class CreateCarDescriptionCommand : IRequest<IResult>
    {
        public Guid CarId { get; set; }
        public string Details { get; set; }
    }
}
