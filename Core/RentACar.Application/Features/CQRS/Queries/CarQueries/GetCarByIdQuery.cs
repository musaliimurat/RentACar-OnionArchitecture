using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.CarResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery(Guid id) : IRequest<IDataResult<GetCarByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
