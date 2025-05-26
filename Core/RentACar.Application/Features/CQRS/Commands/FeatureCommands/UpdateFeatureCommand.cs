using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateFeatureCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
