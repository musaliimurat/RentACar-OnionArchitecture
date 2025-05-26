using MediatR;
using RentACar.Application.Features.CQRS.Commands.TestimonialCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.TestimonialWriteHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, IResult>
    {
        private readonly ITestimonialRepository _testimonialRepository;
        public UpdateTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
        public async Task<IResult> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialRepository.GetAsync(f => f.Id == request.Id);
            if (testimonial == null) return new ErrorResult("Testimonial update error!");
            testimonial.Name = request.Name;
            testimonial.Title = request.Title;
            testimonial.Comment = request.Comment;
            testimonial.ImageUrl = request.ImageUrl;

            await _testimonialRepository.UpdateAsync(testimonial);
            return new SuccessResult("Testimonial updated successfully!");
        }
    }
   
}
