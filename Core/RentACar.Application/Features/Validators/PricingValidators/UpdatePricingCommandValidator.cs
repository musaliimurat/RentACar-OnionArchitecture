using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;

namespace RentACar.Application.Features.Validators.PricingValidators
{
    public class UpdatePricingCommandValidator : AbstractValidator<CreatePricingCommand>
    {
        public UpdatePricingCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Pricing name is required.")
                .Length(2, 50).WithMessage("Pricing name must be between 2 and 50 characters.");
        }
    }
}
