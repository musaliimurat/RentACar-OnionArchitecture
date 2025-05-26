using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.AuthorCommands
{
    public class CreateAuthorCommand : IRequest<IResult>
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
