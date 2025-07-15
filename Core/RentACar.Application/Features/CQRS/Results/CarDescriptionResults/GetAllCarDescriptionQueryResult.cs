using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Results.CarDescriptionResults
{
    public class GetAllCarDescriptionQueryResult
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public string Model { get; set; }
        public string BrandName { get; set; }
        public string Details { get; set; }
        public string CoverPhotoUrl { get; set; }
    }
}
