using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;

namespace RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands
{
    [WithValidation]
    public class UpdateCarDescriptionCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Details { get; set; }
    }
}
