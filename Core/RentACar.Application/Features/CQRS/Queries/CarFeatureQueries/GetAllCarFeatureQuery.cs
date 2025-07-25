using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetAllCarFeatureQuery : IRequest<IDataResult<List<GetAllCarFeatureQueryResult>>>
    {
    }
}
