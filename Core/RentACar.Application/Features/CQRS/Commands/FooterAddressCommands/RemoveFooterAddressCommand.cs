using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class RemoveFooterAddressCommand(Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
