using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.PricingCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.PricingValidators
{
    public class CreatePricingCommandValidator : AbstractValidator<CreatePricingCommand>
    {
        public CreatePricingCommandValidator()
        {
            RuleFor(p=>p.Name)
                .NotEmpty().WithMessage("Pricing name is required.")
                .Length(2, 50).WithMessage("Pricing name must be between 2 and 50 characters.");
        }
    }
}
