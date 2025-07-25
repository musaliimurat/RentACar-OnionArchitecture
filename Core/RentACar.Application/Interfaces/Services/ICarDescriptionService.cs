﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Concrete.CarDescriptionDTOs;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface ICarDescriptionService
    {
        Task<IDataResult<List<GetAllCarDescriptionDto>>> GetAllCarDescriptionsAsync();
        Task<IDataResult<GetCarDescriptionByIdDto>> GetCarDescriptionByIdAsync(Guid id);
        Task<IResult> CreateCarDescriptionAsync(CreateCarDescriptionDto createCarDescriptionDto);
        Task<IResult> UpdateCarDescriptionAsync(UpdateCarDescriptionDto updateCarDescriptionDto);
        Task<IResult> DeleteCarDescriptionAsync(Guid id);
    }
}
