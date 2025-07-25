using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface IPricingToCarRepository: IRepositoryBase<PricingToCar>
    {
        Task<List<PricingToCar>> GetAllWithDetailsAsync();
        Task<PricingToCar> GetWithDetailByIdAsync(Guid id);
    }
}
