using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.CategoryValidators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .Length(2, 50).WithMessage("Category name must be between 2 and 50 characters long.");
        }
    }
}
