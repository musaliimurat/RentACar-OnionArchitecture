using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.AuthorReadHandlers
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IDataResult<List<GetAllAuthorQueryResult>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<List<GetAllAuthorQueryResult>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _authorRepository.GetAllAsync();
            var result = _mapper.Map<List<GetAllAuthorQueryResult>>(values);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<GetAllAuthorQueryResult>>(result, "Author list load successfull!");
            }
            else return new ErrorDataResult<List<GetAllAuthorQueryResult>>("Author list is empty!");
        }
    }
    }
