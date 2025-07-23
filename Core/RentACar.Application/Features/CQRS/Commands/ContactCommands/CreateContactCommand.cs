using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.ContactCommands
{
    [WithValidation]
    public class CreateContactCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }
    }
}
