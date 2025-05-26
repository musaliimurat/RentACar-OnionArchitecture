using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.TestimonialValidators
{
    public class CreateTestimonialCommandValidator : AbstractValidator<CreateTestimonialCommand>
    {
        public CreateTestimonialCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MinimumLength(3);
            RuleFor(f => f.Title).NotEmpty().MinimumLength(5);
            RuleFor(f => f.Comment).NotEmpty().MinimumLength(5);
            RuleFor(f => f.ImageUrl).NotEmpty().WithMessage("ImageUrl is required!");
        }
    }
}
