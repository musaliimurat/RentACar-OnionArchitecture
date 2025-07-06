using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.FeatureValidators
{
    public class UpdateFeatureCommandValidator : AbstractValidator<UpdateFeatureCommand>
    {
        public UpdateFeatureCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Feature name cannot be empty.")
                .Length(2, 50).WithMessage("Feature name must be between 2 and 50 characters.");
        }
    }
}
