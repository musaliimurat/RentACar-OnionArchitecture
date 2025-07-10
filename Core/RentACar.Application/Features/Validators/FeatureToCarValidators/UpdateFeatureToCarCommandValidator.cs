using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.CarFeatureCommands;

namespace RentACar.Application.Features.Validators.FeatureToCarValidators
{
    public class UpdateFeatureToCarCommandValidator : AbstractValidator<UpdateFeatureToCarCommand>
    {
        public UpdateFeatureToCarCommandValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("Car ID cannot be empty.")
                .NotNull().WithMessage("Car ID cannot be null.");
            RuleFor(x => x.SelectedFeatureId)
                .NotEmpty().WithMessage("Feature ID cannot be empty.")
                .NotNull().WithMessage("Feature ID cannot be null.");
        }
    }
}
