using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateBannerCommand : IRequest<IResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
