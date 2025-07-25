using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Pagination;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.BlogQueries
{
    public class GetAllBlogByCategoryQuery(Guid id) : PaginatedRequest, IRequest<IDataResult<PaginatedList<GetAllBlogDto>>>
    {
        public Guid CategoryId { get; set; } = id;
    }
}
