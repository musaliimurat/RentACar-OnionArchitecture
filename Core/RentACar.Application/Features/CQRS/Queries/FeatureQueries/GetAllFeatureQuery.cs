using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.FeatureResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetAllFeatureQuery : IRequest<IDataResult<List<GetAllFeatureQueryResult>>>
    {
    }
}
