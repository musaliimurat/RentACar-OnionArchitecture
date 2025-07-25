using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Common;

namespace RentACar.Domain.Entities.Concrete
{
    public class Author : BaseEntity
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
