using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Features.CQRS.Handlers.Write.CarWriteHandlers;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Tests.UnitTests.Common;
using RentACar.Domain.Entities.Concrete;
using Xunit;

namespace RentACar.Application.Tests.UnitTests.Features.CQRS.Handlers.Write.CarTestWriteHandlers
{
    public class CreateCarCommandHandlerTest : HandlerTestBase
    {
        private readonly Mock<ICarRepository> _carRepositoryMock;

        public CreateCarCommandHandlerTest()
        {
            _carRepositoryMock = new Mock<ICarRepository>();
        }

        [Fact]
        public async Task Handle_ShouldCallCreateAsync_WithMappedEntity()
        {
            var brands = FakeCarData.GetBrandsEntities();

            var createCarCommand = new CreateCarCommand
            {
                BrandId = brands[0].Id,
                Model = "A-Class",
                CoverImageUrl = "cover.jpg",
                DetailImageUrl = "detail.jpg",
                Km = 10000,
                Transmission = "Automatic",
                Seat = 5,
                Luggage = 2,
                Fuel = "Benzin"
            };
            var carEntity = new Car
            {
                BrandId = createCarCommand.BrandId,
                Model = createCarCommand.Model,
                CoverImageUrl = createCarCommand.CoverImageUrl,
                DetailImageUrl = createCarCommand.DetailImageUrl,
                Km = createCarCommand.Km,
                Transmission = createCarCommand.Transmission,
                Seat = createCarCommand.Seat,
                Luggage = createCarCommand.Luggage,
                Fuel = createCarCommand.Fuel
                
            };
            _carRepositoryMock.Setup(r => r.CreateAsync(carEntity));

            var handler = new CreateCarCommandHandler(_carRepositoryMock.Object);

            await handler.Handle(createCarCommand, CancellationToken.None);


            _carRepositoryMock.Verify(r => r.CreateAsync(It.Is<Car>(c=>
            c.Fuel == "Benzin")), Times.Once);
        }
    }
}
