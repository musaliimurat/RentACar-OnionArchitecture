using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand : IRequest<IResult>
    {
        public string Name { get; set; }
    }
}
