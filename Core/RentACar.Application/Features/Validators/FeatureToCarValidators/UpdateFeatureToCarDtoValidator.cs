using FluentValidation;
using RentACar.Application.DTOs.Concrete.FeatureToCarDTOs;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;

namespace RentACar.Application.Features.Validators.FeatureToCarValidators
{
    public class UpdateFeatureToCarDtoValidator : AbstractValidator<UpdateFeatureToCarDto>
    {
        public UpdateFeatureToCarDtoValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car ID cannot be empty.")
                .NotNull().WithMessage("Car ID cannot be null.");
            RuleFor(x => x.FeatureId)
                .NotEmpty().WithMessage("Feature ID cannot be empty.")
                .NotNull().WithMessage("Feature ID cannot be null.");
        }
    }
}
