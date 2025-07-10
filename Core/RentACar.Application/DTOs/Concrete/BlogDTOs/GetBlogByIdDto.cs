using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.BlogDto
{
    public class GetBlogByIdDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid AuthorId { get; set; }
        public string FullName { get; set; }
        public string AuthorImageUrl { get; set; }
        public string AuthorDescription { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
