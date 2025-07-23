using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;

namespace RentACar.Application.Features.CQRS.Commands.CarFeatureCommands
{
    [WithValidation]
    public class UpdateFeatureToCarCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
