using Microsoft.AspNetCore.Http;
using RentACar.Application.DTOs.Abstract;

namespace RentACar.Application.DTOs.Concrete.BlogDTOs
{
    public class UpdateBlogDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsNew { get; set; }
    }
}
