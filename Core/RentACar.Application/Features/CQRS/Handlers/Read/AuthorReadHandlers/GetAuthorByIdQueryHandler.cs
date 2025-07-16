using AutoMapper;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.AuthorQueries;
using RentACar.Application.Features.CQRS.Results.AuthorResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.AuthorReadHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, IDataResult<GetAuthorByIdQueryResult>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<IDataResult<GetAuthorByIdQueryResult>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _authorRepository.GetAsync(x => x.Id == request.Id);
            if (value != null)
            {
                var result = _mapper.Map<GetAuthorByIdQueryResult>(value);
                return new SuccessDataResult<GetAuthorByIdQueryResult>(result, "Author load successfull!");
            }
            else return new ErrorDataResult<GetAuthorByIdQueryResult>("Author not found!");
        }
    }
    }
