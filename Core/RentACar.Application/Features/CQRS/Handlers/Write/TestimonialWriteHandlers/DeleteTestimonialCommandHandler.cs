using MediatR;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.TestimonialWriteHandlers
{
    public class DeleteTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand, IResult>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public DeleteTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public async Task<IResult> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialRepository.GetAsync(f => f.Id == request.Id);
            if (testimonial == null) return new ErrorResult("Testimonial delete error!");
            await _testimonialRepository.RemoveAsync(testimonial);
            return new SuccessResult("Testimonial deleted successfully!");
        }
    }
   
}
