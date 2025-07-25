using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using RentACar.Application.Features.CQRS.Results.TestimonialResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface ITestimonialService
    {
        Task<IResult> CreateTestimonialAsync(CreateTestimonialCommand command);
        Task<IResult> UpdateTestimonialAsync(UpdateTestimonialCommand command);
        Task<IResult> DeleteTestimonialAsync(Guid id);
        Task<IDataResult<List<GetAllTestimonialQueryResult>>> GetAllTestimonialAsync();
        Task<IDataResult<GetTestimonialByIdQueryResult>> GetTestimonialByIdAsync(Guid id);
    }
}
