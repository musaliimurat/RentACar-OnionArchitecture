﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Common.Utilities.Results.Abstract;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Application.Features.CQRS.Handlers.Write.ContactWriteHandlers
{
    public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand, IResult>
    {
        private readonly IContactRepository _contactRepository;

        public RemoveContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IResult> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetAsync(c=>c.Id == request.Id);
            if (value != null) 
            {
                await _contactRepository.RemoveAsync(value);
                return new SuccessResult("Contact is removed successfully!");
            }
            else return new ErrorResult("Contact is not removed!");
        }
    }
}
