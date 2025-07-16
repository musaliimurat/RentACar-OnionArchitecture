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
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery , IDataResult<List<GetAllCategoryQueryResult>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllCategoryQueryResult>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllCategoryQueryResult>>(values);
            if (result.Count >0 )
            {
                return new SuccessDataResult<List<GetAllCategoryQueryResult>>(result, "Category list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCategoryQueryResult>>("Category list is not found!");
        }
    }
}
