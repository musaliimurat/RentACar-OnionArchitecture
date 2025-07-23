using AutoMapper;
using FluentAssertions;
using Moq;
using RentACar.Application.Features.CQRS.Handlers.Read.CarReadHandlers;
using RentACar.Application.Features.CQRS.Queries.CarQueries;
using RentACar.Application.Interfaces.Repository.Abstract;
using RentACar.Application.Tests.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RentACar.Application.Tests.UnitTests.Features.CQRS.Handlers.Read.CarTestReadHandlers
{
    public class GetAllCarsWithBrandNameQueryHandlerTest : HandlerTestBase
    {
        private readonly Mock<ICarRepository> _carRepositoryMock = new();

        [Fact]
        public async Task Handle_ShouldReturnMappedDtoList_GetAllCarsWithBrandName()
        {
            var cars = FakeCarData.GetCarsEntities();
            var carDtos = FakeCarData.GetCarDtos();

            _carRepositoryMock.Setup(repo=> repo.GetAllCarsReadAsync())
            .ReturnsAsync(carDtos);

            var handler = new GetAllCarWithBrandNameQueryHandler(_carRepositoryMock.Object);

            // Act
            var result = await handler.Handle(new GetAllCarWithBrandNameQuery(), CancellationToken);

            // Assert
            result.Data.Items.Should().NotBeNull();
            result.Data.Items.Should().HaveCount(3);
            result.Data.Items.Should().Contain(x => x.BrandName == "Toyota" && x.Model == "Corolla");
        }
    }
}
