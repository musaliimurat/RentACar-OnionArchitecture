using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.CategoryQueries;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.CategoryReadHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, IDataResult<GetCategoryByIdQueryResult>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<GetCategoryByIdQueryResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            
            if (value != null)
            {
                var result = _mapper.Map<GetCategoryByIdQueryResult>(value);
                return new SuccessDataResult<GetCategoryByIdQueryResult>(result, "Category is load successfull!");
            }
            else return new ErrorDataResult<GetCategoryByIdQueryResult>("Category is not found!");
        }
    }
}
