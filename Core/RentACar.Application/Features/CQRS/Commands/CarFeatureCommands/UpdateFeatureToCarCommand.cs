using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class UpdateFeatureToCarCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
