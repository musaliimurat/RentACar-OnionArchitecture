using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Queries.TestimonialQueries;
using RentACar.Application.Features.CQRS.Results.TestimonialResults;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
// Ignore Spelling: CQRS

namespace RentACar.Application.Features.CQRS.Handlers.Read.TestimonialReadHandlers
{
    public class GetAllTestimonialQueryHandler : IRequestHandler<GetAllTestimonialQuery, IDataResult<List<GetAllTestimonialQueryResult>>>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public GetAllTestimonialQueryHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<IDataResult<List<GetAllTestimonialQueryResult>>> Handle(GetAllTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _testimonialRepository.GetAllAsync();
            var result = values.Select(f => new GetAllTestimonialQueryResult
            {
                Id = f.Id,
                Name = f.Name,
                Title = f.Title,
                Comment = f.Comment,
                ImageUrl = f.ImageUrl,
            }).ToList();
            if (result.Count > 0) 
            {
                return new SuccessDataResult<List<GetAllTestimonialQueryResult>>(result, "Testimonial list is load successfully!");
            }
            else return new ErrorDataResult<List<GetAllTestimonialQueryResult>>("Testimonial list is not found!");
        }
        }
    }
