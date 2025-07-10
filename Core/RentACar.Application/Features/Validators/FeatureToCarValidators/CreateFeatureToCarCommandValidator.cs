using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.FeatureToCarValidators
{
    public class CreateFeatureToCarCommandValidator : AbstractValidator<CreateFeatureToCarCommand>
    {
        public CreateFeatureToCarCommandValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car ID cannot be empty.")
                .NotNull().WithMessage("Car ID cannot be null.");
            RuleFor(x => x.SelectedFeatureIds)
                .NotEmpty().WithMessage("Feature ID cannot be empty.")
                .NotNull().WithMessage("Feature ID cannot be null.");
        }
    }
}
