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

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
       
        public async Task<IDataResult<List<GetAllCategoryQueryResult>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var values = await _categoryRepository.GetAllAsync();
            var result = values.Select(c => new GetAllCategoryQueryResult
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();
            if (result.Count >0 )
            {
                return new SuccessDataResult<List<GetAllCategoryQueryResult>>(result, "Category list is load successfull!");
            }
            else return new ErrorDataResult<List<GetAllCategoryQueryResult>>("Category list is not found!");
        }
    }
}
