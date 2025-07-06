using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;

namespace RentACar.Application.Features.Validators.BrandValidators
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Brand name cannot be empty.")
                .Length(2, 50).WithMessage("Brand name must be between 2 and 50 characters long.");
        }
    }
}
