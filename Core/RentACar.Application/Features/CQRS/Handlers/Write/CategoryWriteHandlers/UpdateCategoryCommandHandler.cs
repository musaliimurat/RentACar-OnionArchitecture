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
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _categoryRepository.GetAsync(c => c.Id == request.Id);
            if (value != null)
            {
                value.Name = request.Name;
                value.UpdateDate = DateTime.Today;

                await _categoryRepository.UpdateAsync(value);
                return new SuccessResult("Category is updated successfully!");
            }
            else return new ErrorResult("Category is not updated!");
        }
    }
}
