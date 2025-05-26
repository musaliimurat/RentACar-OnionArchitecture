using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Results.BlogResults;
using RentACar.Application.Pagination;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.BlogQueries
{
    public class GetAllBlogQuery : PaginatedRequest, IRequest<IDataResult<PaginatedList<GetAllBlogDto>>>
    {
    }
}
