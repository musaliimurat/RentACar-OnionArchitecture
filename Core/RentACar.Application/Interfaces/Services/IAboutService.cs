﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface IAboutService
    {
        Task<IDataResult<List<GetAllAboutQueryResult>>> GetAllAboutAsync();
        Task<IDataResult<GetAboutByIdQueryResult>> GetAboutByIdAsync(Guid id);
        Task<IResult> CreateAboutAsync(CreateAboutCommand command);
        Task<IResult> UpdateAboutAsync(UpdateAboutCommand command);
        Task<IResult> DeleteAboutAsync(Guid id);
    }
}
