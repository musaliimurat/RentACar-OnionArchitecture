﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Common.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult where T : class, new()
    {
        T Data { get; }
    }
}
