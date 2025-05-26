using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Utilities.Results.Concrete
{

    public class Result(bool success /* Primary constructor */) : IResult
    {
        public bool Success { get; } = success;
        public string Message { get;} = string.Empty;

        //nested constructor
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        
    }
}
