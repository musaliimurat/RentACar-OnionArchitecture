﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class About : BaseEntity
    {
        public string Title { get;  set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
