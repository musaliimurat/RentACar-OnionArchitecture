using RentACar.Application.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.DTOs.Concrete.BlogDto
{
    public class GetAllBlogWithCategoryNameDto : IDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string BlogTitle { get; set; }
        public string CategoryTitle { get; set; }
        public int BlogWithCatgoryCount { get; set; }
    }
}
