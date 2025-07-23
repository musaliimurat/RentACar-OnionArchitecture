using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Commands.CategoryCommands
{
    [WithValidation]
    public class CreateCategoryCommand : IRequest<IResult>
    {
        public string Name { get; set; }
    }
}
