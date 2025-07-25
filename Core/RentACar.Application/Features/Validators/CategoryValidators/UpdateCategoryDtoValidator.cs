using FluentValidation;
using RentACar.Application.DTOs.Concrete.CaregoryDTOs;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;

namespace RentACar.Application.Features.Validators.CategoryValidators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .Length(2, 50).WithMessage("Category name must be between 2 and 50 characters long.");
        }
    }
}
