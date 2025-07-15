using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface IPricingToCarRepository: IRepositoryBase<PricingToCar>
    {
        Task<List<PricingToCar>> GetAllWithDetailsAsync();
        Task<PricingToCar> GetWithDetailByIdAsync(Guid id);
    }
}
