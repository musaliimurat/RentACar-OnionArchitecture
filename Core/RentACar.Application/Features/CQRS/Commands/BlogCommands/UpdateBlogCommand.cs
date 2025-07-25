using MediatR;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Commands.BlogCommands
{
    public class UpdateBlogCommand : IRequest<IResult>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; }
    }
}
