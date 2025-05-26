using MediatR;
using RentACar.Application.Features.CQRS.Queries.BrandQueries;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.BrandReadHandlers
{
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, IDataResult<GetBrandByIdQueryResult>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandByIdQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }


        public async Task<IDataResult<GetBrandByIdQueryResult>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetAsync(b => b.Id == request.Id);
            if (value != null)
            {
                var result = new GetBrandByIdQueryResult()
                {
                    Id = value.Id,
                    Name = value.Name,
                };
                return new SuccessDataResult<GetBrandByIdQueryResult>(result, "Brand load is successfull!");
            }
            else return new ErrorDataResult<GetBrandByIdQueryResult>("Brand not found!");
        }
    }
}
