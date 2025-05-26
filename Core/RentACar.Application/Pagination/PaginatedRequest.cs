using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Pagination
{
    public class PaginatedRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 3;

        public int Skip => (Page - 1) * PageSize;
        public int Take => PageSize;
    }
}
