using MediatR;
using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.AboutReadHandlers
{
    public class GetAllAboutQueryHandler : IRequestHandler<GetAllAboutQuery, IDataResult<List<GetAllAboutQueryResult>>>
    {
        private readonly IAboutRepository _aboutRepository;

        public GetAllAboutQueryHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<IDataResult<List<GetAllAboutQueryResult>>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _aboutRepository.GetAllAsync();
            var result = values.Select(a => new GetAllAboutQueryResult
            {
                Id = a.Id,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllAboutQueryResult>>(result, "About list load successfull!");
            }
            else return new ErrorDataResult<List<GetAllAboutQueryResult>>("About list is empty!");
        }
    }
}
