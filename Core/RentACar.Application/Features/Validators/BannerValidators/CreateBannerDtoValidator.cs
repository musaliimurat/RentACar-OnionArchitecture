﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using RentACar.Application.DTOs.Concrete.BannerDTOs;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;

namespace RentACar.Application.Features.Validators.BannerValidators
{
    public class CreateBannerDtoValidator : AbstractValidator<CreateBannerDto>
    {
        public CreateBannerDtoValidator() 
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");
            RuleFor(b => b.Description)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
            RuleFor(b => b.VideoDescription)
                .NotEmpty().WithMessage("Description cannot be empty")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");
            RuleFor(b => b.VideoUrl)
                .NotEmpty().WithMessage("Image URL cannot be empty")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Image URL must be a valid absolute URL");
        }
    }
}
