using MediatR;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Read.AuthorReadHandlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IDataResult<List<GetAllAuthorQueryResult>>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IDataResult<List<GetAllAuthorQueryResult>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _authorRepository.GetAllAsync();
            var result = values.Select(a => new GetAllAuthorQueryResult
            {
                Id = a.Id,
                FullName = a.FullName,
                Description = a.Description,
                ImageUrl = a.ImageUrl,
                CreatedDate = a.CreatedDate,
                UpdateDate = a.UpdateDate
            }).ToList();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllAuthorQueryResult>>(result, "Author list load successfull!");
            }
            else return new ErrorDataResult<List<GetAllAuthorQueryResult>>("Author list is empty!");
        }
    }
    }
