﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BrandReadHandlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, IDataResult<GetBrandByIdQueryResult>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }


        public async Task<IDataResult<GetBrandByIdQueryResult>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                var result = _mapper.Map<GetBrandByIdQueryResult>(value); 

                return new SuccessDataResult<GetBrandByIdQueryResult>(result, "Brand load is successfull!");
            }
            else return new ErrorDataResult<GetBrandByIdQueryResult>("Brand not found!");
        }
    }
}
