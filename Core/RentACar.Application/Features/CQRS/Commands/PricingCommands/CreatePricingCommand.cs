using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.PricingCommands
{
    public class CreatePricingCommand : IRequest<IResult>
    {
        public string Name { get; set; }
    }
}
