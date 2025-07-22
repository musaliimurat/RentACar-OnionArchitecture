using RentACar.Application.DTOs.Concrete.CarDto;
using RentACar.Domain.Entities.Concrete;

namespace RentACar.Application.Tests.UnitTests.Common
{
    public static class FakeCarData
    {
        private static readonly List<Brand> Brands = new()
    {
        new Brand { Name = "Mercedes" },
        new Brand { Name = "Bmw" },
        new Brand { Name = "Toyota" }
    };

        private static readonly List<Car> Cars = new()
    {
        new Car
        {
            BrandId = Brands[0].Id,
            Brand = Brands[0],
            Model = "ML 350",
            Fuel = "Diesel",
            Transmission = "Automatic",
            Seat = 5,
            Luggage = 3,
            Km = 50000,
            CoverImageUrl = "img1.jpg",
            DetailImageUrl = "img2.jpg",
        },
        new Car
        {
            BrandId = Brands[1].Id,
            Brand = Brands[1],
            Model = "X5",
            Fuel = "Petrol",
            Transmission = "Automatic",
            Seat = 5,
            Luggage = 4,
            Km = 30000,
            CoverImageUrl = "img1.jpg",
            DetailImageUrl = "img2.jpg",
        },
        new Car
        {
            BrandId = Brands[2].Id,
            Brand = Brands[2],
            Model = "Corolla",
            Fuel = "Hybrid",
            Transmission = "Automatic",
            Seat = 5,
            Luggage = 2,
            Km = 20000,
            CoverImageUrl = "img1.jpg",
            DetailImageUrl = "img2.jpg",
        }
    };

        public static List<Brand> GetBrandsEntities() => Brands;

        public static List<Car> GetCarsEntities() => Cars;

        public static List<GetAllCarsWithBrandNameDto> GetCarDtos()
        {
            var getAllCarsWithBrandNameDtos = new List<GetAllCarsWithBrandNameDto>();

            foreach (var car in Cars)
            {
                getAllCarsWithBrandNameDtos.Add(new GetAllCarsWithBrandNameDto
                {
                    Id = car.Id,
                    Model = car.Model,
                    BrandId = car.BrandId,
                    BrandName = car.Brand.Name,
                    Fuel = car.Fuel,
                    Transmission = car.Transmission,
                    Seat = car.Seat,
                    Luggage = car.Luggage,
                    Km = car.Km,
                    CoverImageUrl = car.CoverImageUrl,
                    DetailImageUrl = car.DetailImageUrl
                });
            }

            return getAllCarsWithBrandNameDtos;
        }
    }
}
