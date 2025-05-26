using RentACar.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entities.Concrete
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsNew { get; set; } = false;
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
