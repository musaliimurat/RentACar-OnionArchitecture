using MediatR;
using RentACar.Application.Features.CQRS.Queries.TestimonialQueries;
using RentACar.Application.Features.CQRS.Results.TestimonialResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, IDataResult<GetTestimonialByIdQueryResult>>
{
    private readonly ITestimonialRepository _testimonialRepository;

    public GetTestimonialByIdQueryHandler(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    public async Task<IDataResult<GetTestimonialByIdQueryResult>> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _testimonialRepository.GetAsync(t=>t.Id == request.Id);
        if(value == null) return new ErrorDataResult<GetTestimonialByIdQueryResult>("Testimonial is not found!");
        else
        {
            var result = new GetTestimonialByIdQueryResult
            {
                Id = value.Id,
                Name = value.Name,
                Title = value.Title,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
            };
            return new SuccessDataResult<GetTestimonialByIdQueryResult>(result, "Testimonial is load successfully!");
        }
    }
}
