using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.FeatureDto;
using RentACar.Application.Features.CQRS.Commands.FeatureCommands;

namespace RentACar.Application.Features.Validators.FeatureValidators
{
    public class UpdateFeatureDtoValidator : AbstractValidator<UpdateFeatureDto>
    {
        public UpdateFeatureDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Feature name cannot be empty.")
                .Length(2, 50).WithMessage("Feature name must be between 2 and 50 characters.");
        }
    }
}
