using FluentValidation;
using RentACar.Application.DTOs.Concrete.TestimonialDTOs;

namespace RentACar.Application.Features.Validators.TestimonialValidators
{
    public class UpdateTestimonialDtoValidator : AbstractValidator<UpdateTestimonialDto>
    {
        public UpdateTestimonialDtoValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MinimumLength(3);
            RuleFor(f => f.Title).NotEmpty().MinimumLength(5);
            RuleFor(f => f.Comment).NotEmpty().MinimumLength(5);
            RuleFor(f => f.ImageUrl).NotEmpty().WithMessage("ImageUrl is required!");
        }
    }
}
