using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Common.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T> where T : class, new()
    {
        public T Data { get; }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }


    }
}
