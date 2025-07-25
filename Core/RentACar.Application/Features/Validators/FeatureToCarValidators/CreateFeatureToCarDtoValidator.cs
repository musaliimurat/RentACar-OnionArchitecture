using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;

namespace RentACar.Application.Features.Validators.FeatureToCarValidators
{
    public class CreateFeatureToCarDtoValidator : AbstractValidator<CreateFeatureToCarDto>
    {
        public CreateFeatureToCarDtoValidator()
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
