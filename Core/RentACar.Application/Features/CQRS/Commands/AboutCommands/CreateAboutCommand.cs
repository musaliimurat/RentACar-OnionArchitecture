using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand : IRequest<IResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
