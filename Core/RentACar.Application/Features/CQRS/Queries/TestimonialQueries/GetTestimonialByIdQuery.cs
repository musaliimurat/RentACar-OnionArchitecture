using MediatR;
using RentACar.Application.Features.CQRS.Results.TestimonialResults;
using RentACar.Application.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery(Guid id) : IRequest<IDataResult<GetTestimonialByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
    
}
