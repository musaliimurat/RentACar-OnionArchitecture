using MediatR;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Common.Attributes;

namespace RentACar.Application.Features.CQRS.Commands.TestimonialCommands
{
    [WithValidation]
    public class UpdateTestimonialCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
