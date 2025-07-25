using MediatR;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.CategoryWriteHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, IResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new()
            {
                Name = request.Name
            };
            if (request != null)
            {
                await _categoryRepository.CreateAsync(category);
                return new SuccessResult("Category is added successfully!");
            }
            else
            {
                return new ErrorResult("Category is not added!");
            }
        }
    }
}
