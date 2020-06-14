using System.Collections.Generic;

using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;

namespace CourierKata.Services.Tests.CostCalculator
{
    public static class CostCalculatorTestData
    {
        public static IEnumerable<object[]> DimensionsTestData =>
            new[]
            {
                new object[] {new ParcelDimensions(1, 1, 1), new CostEstimation("Small", 8m, 8m)},
            };
    }
}