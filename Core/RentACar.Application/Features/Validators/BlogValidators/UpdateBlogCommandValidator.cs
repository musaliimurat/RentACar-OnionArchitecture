using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;

namespace RentACar.Application.Features.Validators.BlogValidators
{
    public class UpdateBlogCommandValidator : AbstractValidator<UpdateBlogCommand>
    {
        public UpdateBlogCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title is required.");
            RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("Content is required.");
            RuleFor(x => x.AuthorId).NotEmpty().NotNull().WithMessage("Author ID is required.");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("Category ID is required.");
            RuleFor(x => x.ImageUrl).NotNull().NotNull().WithMessage("Image file is required.");
        }
    }

}
