using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.BlogQueries
{
    public class GetAllBlogIsNewQuery : IRequest<IDataResult<List<GetAllBlogDto>>>
    {
    }
}
