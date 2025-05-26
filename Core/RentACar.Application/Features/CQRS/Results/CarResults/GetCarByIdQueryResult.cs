using RentACar.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Results.CarResults
{
    public class GetCarByIdQueryResult
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string DetailImageUrl { get; set; }
        public decimal Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
    }
}
