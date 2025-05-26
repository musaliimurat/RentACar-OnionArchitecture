using MediatR;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Utilities.Results.Abstract;
using RentACar.Application.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CategoryWriteHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            if (value != null)
            {
                await _categoryRepository.RemoveAsync(value);
                return new SuccessResult("Category is removed successfully!");
            }
            else return new ErrorResult("Category is not removed!");
        }
    }
}
