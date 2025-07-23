using FluentValidation;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Validators.CarValidators
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator() 
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c=>c.Model).MinimumLength(2).WithMessage("minimum 2 uzunluqlu olmalidir!").NotEmpty().WithMessage("Bosh gonderile bilmez!");
            RuleFor(c=>c.Transmission).NotEmpty().ToString();
            RuleFor(c=>c.Fuel).NotEmpty().ToString();
            RuleFor(c=>c.Seat).Must(val => val > 0).NotEmpty();
            RuleFor(c=>c.Luggage).Must(val => val > 0).NotEmpty();
            RuleFor(c=>c.Km).GreaterThan(-1).WithMessage("Menfi reqem daxil oluna bilmez").NotNull();
            RuleFor(c=>c.CoverImageUrl).NotEmpty().ToString();
            RuleFor(c => c.DetailImageUrl).NotEmpty().ToString();
        }
    }
}
