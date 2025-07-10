using MediatR;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class UpdateFeatureToCarCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid SelectedFeatureId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
