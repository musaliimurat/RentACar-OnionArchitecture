using MediatR;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.ServiceQueries
{
    public class GetAllServiceQuery : IRequest<IDataResult<List<GetAllServiceQueryResult>>>
    {
    }
}
