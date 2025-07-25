﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery(Guid id) : IRequest<IDataResult<GetAboutByIdQueryResult>>
    {
        public Guid Id { get; set; } = id;
    }
}
