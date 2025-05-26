using MediatR;
using RentACar.Application.DTOs.Concrete.BlogDto;
using RentACar.Application.Features.CQRS.Results.BlogResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.BlogQueries
{
    public class GetBlogByIdQuery(Guid id) : IRequest<IDataResult<GetBlogByIdDto>>
    {
        public Guid Id { get; set; } = id;
    }
}
