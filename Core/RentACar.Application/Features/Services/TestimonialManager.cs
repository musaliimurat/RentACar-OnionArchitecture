using MediatR;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using RentACar.Application.Features.CQRS.Queries.TestimonialQueries;
using RentACar.Application.Features.CQRS.Results.TestimonialResults;
using RentACar.Application.Interfaces.Services;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Services
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly IMediator _mediator;

        public TestimonialManager(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IResult> CreateTestimonialAsync(CreateTestimonialCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<IResult> DeleteTestimonialAsync(Guid id)
        {
            return await _mediator.Send(new RemoveTestimonialCommand(id));
        }

        public async Task<IDataResult<List<GetAllTestimonialQueryResult>>> GetAllTestimonialAsync()
        {
            return await _mediator.Send(new GetAllTestimonialQuery());
        }

        public async Task<IDataResult<GetTestimonialByIdQueryResult>> GetTestimonialByIdAsync(Guid id)
        {
            return await _mediator.Send(new GetTestimonialByIdQuery(id));
        }

        public async Task<IResult> UpdateTestimonialAsync(UpdateTestimonialCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
