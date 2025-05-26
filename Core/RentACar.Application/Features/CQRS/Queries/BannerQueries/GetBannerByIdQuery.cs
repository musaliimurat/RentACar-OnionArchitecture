using MediatR;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Queries.BannerQueries
{
    public class GetBannerByIdQuery (Guid id) : IRequest<IDataResult<GetBannerByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
