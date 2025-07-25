using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.TestimonialDTOs;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;

namespace RentACar.Application.Features.Validators.TestimonialValidators
{
    public class CreateTestimonialDtoValidator : AbstractValidator<CreateTestimonialDto>
    {
        public CreateTestimonialDtoValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MinimumLength(3);
            RuleFor(f => f.Title).NotEmpty().MinimumLength(5);
            RuleFor(f => f.Comment).NotEmpty().MinimumLength(5);
            RuleFor(f => f.ImageUrl).NotEmpty().WithMessage("ImageUrl is required!");
        }
    }
}
