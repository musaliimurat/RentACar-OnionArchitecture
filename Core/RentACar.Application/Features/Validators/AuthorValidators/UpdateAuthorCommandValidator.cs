using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.AuthorCommands;

namespace RentACar.Application.Features.Validators.AuthorValidators
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Author name cannot be empty.")
                .Length(2, 50).WithMessage("Author name must be between 2 and 50 characters.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Author name cannot be empty.")
               .Length(10, 500).WithMessage("Author name must be between 10 and 500 characters.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Author image URL cannot be empty.");
        }
    }
}
