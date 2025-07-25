﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.BlogCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.BlogWriteHandlers
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IResult>
    {
        private readonly IBlogRepository _blogRepository;

        public CreateBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IResult> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = new ()
            {
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl,
                IsNew = request.IsNew,
            };
            await _blogRepository.CreateAsync(blog);
            return new SuccessResult("Blog created successfully!");
        }
    }
}
