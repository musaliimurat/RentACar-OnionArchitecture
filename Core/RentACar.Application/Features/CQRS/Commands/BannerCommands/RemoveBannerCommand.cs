using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveBannerCommand(Guid id) : IRequest<IResult>
    {
        public Guid Id { get; set; } = id;
    }
}
