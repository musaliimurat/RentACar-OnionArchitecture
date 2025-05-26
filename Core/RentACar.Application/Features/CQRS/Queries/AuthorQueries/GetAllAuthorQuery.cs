using MediatR;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.AuthorQueries
{
    public class GetAllAuthorQuery : IRequest<IDataResult<List<GetAllAuthorQueryResult>>>
    {
    }
}
