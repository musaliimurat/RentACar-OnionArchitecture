using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Interfaces.Repository.Abstract
{
    public interface ICarFeatureRepository : IRepositoryBase<FeatureToCar>
    {
        Task<List<FeatureToCar>> GetAllWithDetailsAsync();
        Task<FeatureToCar> GetWithDetailByIdAsync(Guid id);

    }
}
