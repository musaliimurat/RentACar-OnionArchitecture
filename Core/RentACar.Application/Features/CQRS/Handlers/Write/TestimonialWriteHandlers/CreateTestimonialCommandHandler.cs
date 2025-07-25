using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.TestimonialWriteHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand, IResult>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public CreateTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<IResult> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            if (request == null) return new ErrorResult("Testimonial add error!");
              Testimonial testimonial = new()
            {
                Name = request.Name,
                Title = request.Title,
                Comment = request.Comment,
                ImageUrl = request.ImageUrl,
            };
            await _testimonialRepository.CreateAsync(testimonial);
            return new SuccessResult("Testimonial added successfully!");
        }
    }
   
}
