using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class CreateFeatureToCarCommand : IRequest<IResult>
    {
        public Guid CarId { get; set; }
        public List<Guid> SelectedFeatureIds { get; set; }
        public bool IsAvailable { get; set; }
    }
}
