using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface ICarDescriptionRepository : IRepositoryBase<CarDescription>
    {
        Task<List<CarDescription>> GetAllCarDescriptionsAsync();
        Task<CarDescription> GetCarDescriptionByIdAsync(Guid id);
    }
}
