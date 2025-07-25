using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Application.Features.CQRS.Commands.ServiceCommands;
using RentACar.Application.Features.CQRS.Results.ServiceResults;
using RentACar.Common.Utilities.Results.Abstract;

namespace RentACar.Application.Interfaces.Services
{
    public interface ICompanyServiceService
    {
        Task<IDataResult<List<GetAllServiceQueryResult>>> GetAllAsync();
        Task<IDataResult<GetServiceByIdQueryResult>> GetByIdAsync(Guid id);
        Task<IResult> CreateAsync(CreateServiceCommand command);
        Task<IResult> UpdateAsync(UpdateServiceCommand command);
        Task<IResult> DeleteAsync(Guid id);
    }
}
