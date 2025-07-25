using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.AboutDTOs;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;

namespace RentACar.Application.Features.Validators.AboutValidators
{
    public class CreateAboutDtoValidator : AbstractValidator<CreateAboutDto>
    {
        public CreateAboutDtoValidator()
        {
            RuleFor(x=>x.Title).MinimumLength(3).NotEmpty().WithMessage("Title is required.");
            RuleFor(x => x.Description).MinimumLength(3).NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image is required.");
        }
    }
}
