using MediatR;
using RentACar.Application.Features.CQRS.Results.FeatureResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery(Guid id) : IRequest<IDataResult<GetFeatureByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
