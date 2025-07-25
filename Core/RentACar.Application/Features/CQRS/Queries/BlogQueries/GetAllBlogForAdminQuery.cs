using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.BlogQueries
{
    public class GetAllBlogForAdminQuery : IRequest<IDataResult<List<GetAllBlogDto>>>
    {
    }
}
