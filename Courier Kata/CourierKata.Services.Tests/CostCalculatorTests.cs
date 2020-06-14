using Xunit;

namespace CourierKata.Services.Tests
{
    public class CostCalculatorTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        public void Test1(
            double length,
            double height,
            double width)
        {
            // Arrange
            var service = new CostCalculator();
            var expectedCost = (Size: "Small", Cost: 8m, TotalCost: 8m);

            // Act
            var result = service.Calculate(length, height, width);

            // Assert
            Assert.Equal(expectedCost, result);
        }
    }
}