﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.FeatureToCarDTOs
{
    public class GetAllFeatureToCarForCarListDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid FeatureId { get; set; }
        public string FeatureName { get; set; }
        public bool IsAvailable { get; set; }
    }
}
