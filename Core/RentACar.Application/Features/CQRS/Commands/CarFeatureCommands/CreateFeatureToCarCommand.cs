using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.CarFeatureCommands
{
    public class CreateFeatureToCarCommand : IRequest<IResult>
    {
        public Guid CarId { get; set; }
        public List<Guid> SelectedFeatureIds { get; set; }
        public bool IsAvailable { get; set; }
    }
}
