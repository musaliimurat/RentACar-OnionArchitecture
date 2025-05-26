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
        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IDataResult<GetAuthorByIdQueryResult>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _authorRepository.GetAsync(x => x.Id == request.Id);
            if (value != null)
            {
                var result = new GetAuthorByIdQueryResult
                {
                    Id = value.Id,
                    FullName = value.FullName,
                    Description = value.Description,
                    ImageUrl = value.ImageUrl,
                    CreatedDate = value.CreatedDate,
                    UpdateDate = value.UpdateDate
                };
                return new SuccessDataResult<GetAuthorByIdQueryResult>(result, "Author load successfull!");
            }
            else return new ErrorDataResult<GetAuthorByIdQueryResult>("Author not found!");
        }
    }
    }
