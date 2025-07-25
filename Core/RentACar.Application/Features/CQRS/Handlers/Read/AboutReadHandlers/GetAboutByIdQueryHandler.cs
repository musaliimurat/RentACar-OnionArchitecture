using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Read.AboutReadHandlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery , IDataResult<GetAboutByIdQueryResult>>
    {
        private readonly IAboutRepository _aboutRepository;

        public GetAboutByIdQueryHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }


        public async Task<IDataResult<GetAboutByIdQueryResult>> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _aboutRepository.GetAsync(a => a.Id == request.Id);
            var result = new GetAboutByIdQueryResult
            {
                Id = value!.Id,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
            if (result !=null)
            {
                return new SuccessDataResult<GetAboutByIdQueryResult>(result, "About load is successfull!");
            }
            else return new ErrorDataResult<GetAboutByIdQueryResult>("About load is failed!");
        }
    }
}
