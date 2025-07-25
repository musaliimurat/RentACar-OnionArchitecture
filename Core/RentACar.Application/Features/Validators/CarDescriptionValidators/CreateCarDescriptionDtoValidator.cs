﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Application.Features.CQRS.Commands.CarDescriptionCommands;

namespace RentACar.Application.Features.Validators.CarDescriptionValidators
{
    public class CreateCarDescriptionDtoValidator : AbstractValidator<CreateCarDescriptionDto>
    {
        public CreateCarDescriptionDtoValidator()
        {
            RuleFor(RuleFor => RuleFor.CarId)
                .NotEmpty().NotNull().WithMessage("Car ID cannot be empty.");
            RuleFor(RuleFor => RuleFor.Details).NotNull()
                .NotEmpty().WithMessage("Details cannot be empty.")
                .MinimumLength(10).WithMessage("Details must be at least 10 characters long.")
                .MaximumLength(500).WithMessage("Details must not exceed 500 characters.");
        }
    }
}
