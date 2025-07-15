using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.CarPricingCommands;

namespace RentACar.Application.Features.Validators.PricingToCarValidators
{
    public class CreatePricingToCarCommandValidator : AbstractValidator<CreatePricingToCarCommand>
    {
        public CreatePricingToCarCommandValidator()
        {
            RuleFor(x => x.CarId)
                .NotEmpty().WithMessage("CarId cannot be empty.")
                .NotNull().WithMessage("CarId cannot be null.");
            RuleFor(x => x.PricingId)
                .NotEmpty().WithMessage("CarId cannot be empty.")
                .NotNull().WithMessage("CarId cannot be null."); ;
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
        }
    }
}
