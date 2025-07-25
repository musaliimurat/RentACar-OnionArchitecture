using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery(Guid id) : IRequest<IDataResult<GetCategoryByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
