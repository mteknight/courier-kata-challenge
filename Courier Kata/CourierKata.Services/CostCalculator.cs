using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;

namespace CourierKata.Services
{
    public class CostCalculator : ICostCalculator
    {
        public CostEstimation Calculate(ParcelDimensions dimensions)
        {
            return new CostEstimation("Small", 8m, 8m);
        }
    }
}