using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;

using Xunit;

namespace CourierKata.Services.Tests.CostCalculator
{
    public class CostCalculatorTests
    {
        private readonly ICostCalculator _service;

        public CostCalculatorTests()
        {
            _service = new Services.CostCalculator();
        }

        [Theory]
        [MemberData(nameof(CostCalculatorTestData.DimensionsTestData), MemberType = typeof(CostCalculatorTestData))]
        public void TestCalculate_WhenValidDimensions_ExpectCheapestEstimation(
            ParcelDimensions dimensions,
            CostEstimation expectedEstimation)
        {
            // Act
            var result = _service.Calculate(dimensions);

            // Assert
            Assert.Equal(expectedEstimation, result);
        }
    }
}