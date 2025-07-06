using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.BrandValidators
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Brand name cannot be empty.")
                .Length(2, 50).WithMessage("Brand name must be between 2 and 50 characters long.");
        }
    }
}
