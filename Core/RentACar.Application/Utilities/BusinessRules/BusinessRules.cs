using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Utilities.BusinessRules
{
    public class BusinessRules
    {
        public static async Task<IResult> Run(Task<IResult> task, params IResult[] logics)
        {
            IResult taskResult = await task;

            if (!taskResult.Success)
            {
                return taskResult;
            }

            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
