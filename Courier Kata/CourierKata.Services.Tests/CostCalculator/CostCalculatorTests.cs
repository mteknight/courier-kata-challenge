using System;
using System.Collections.Generic;

using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;
using CourierKata.Repositories;

using Moq;

using Xunit;

namespace CourierKata.Services.Tests.CostCalculator
{
    public class CostCalculatorTests
    {
        private readonly Mock<IParcelRepository> _parcelRepositoryMock;
        private readonly ICostCalculator _service;

        public CostCalculatorTests()
        {
            _parcelRepositoryMock = new Mock<IParcelRepository>();
            ConfigureRepositoryMock(CostCalculatorTestData.SmallParcel);
            ConfigureRepositoryMock(CostCalculatorTestData.MediumParcel);
            ConfigureRepositoryMock(CostCalculatorTestData.LargeParcel);
            ConfigureRepositoryMock(CostCalculatorTestData.XLParcel);

            _service = new Services.CostCalculator(_parcelRepositoryMock.Object);
        }

        private void ConfigureRepositoryMock(Parcel parcel)
        {
            _parcelRepositoryMock
                .Setup(repository => repository.Get(parcel.Size))
                .Returns(() => parcel);
        }

        [Theory]
        [MemberData(nameof(CostCalculatorTestData.DimensionsTestData), MemberType = typeof(CostCalculatorTestData))]
        public void TestCalculate_WhenValidDimensions_ExpectCheapestEstimation(
            ParcelDimensions dimensions,
            CostEstimation expectedEstimation)
        {
            // Arrange
            var dimensionsCollection = new[] { dimensions };

            // Act
            var result = _service.Calculate(dimensionsCollection);

            // Assert
            Assert.Equal(expectedEstimation, result);
        }

        [Fact]
        public void TestCalculate_WhenParameterIsNull_ExpectArgumentNullException()
        {
            // Arrange
            var dimensionsCollection = default(IEnumerable<ParcelDimensions>);

            // Act
            void SutCall() => _service.Calculate(dimensionsCollection);

            // Assert
            Assert.Throws<ArgumentNullException>(SutCall);
        }
    }
}