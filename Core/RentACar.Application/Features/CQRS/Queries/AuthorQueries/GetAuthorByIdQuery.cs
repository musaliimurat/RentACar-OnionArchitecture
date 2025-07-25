using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.AuthorQueries
{
    public class GetAuthorByIdQuery(Guid id) : IRequest<IDataResult<GetAuthorByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
