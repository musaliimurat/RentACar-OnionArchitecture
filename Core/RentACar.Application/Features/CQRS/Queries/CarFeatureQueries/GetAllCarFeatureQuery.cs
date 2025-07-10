using MediatR;
using RentACar.Application.Features.CQRS.Results.CarFeatureResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.CarFeatureQueries
{
    public class GetAllCarFeatureQuery : IRequest<IDataResult<List<GetAllCarFeatureQueryResult>>>
    {
    }
}
