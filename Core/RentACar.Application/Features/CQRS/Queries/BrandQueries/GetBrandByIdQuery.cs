using MediatR;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery(Guid id) : IRequest<IDataResult<GetBrandByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
