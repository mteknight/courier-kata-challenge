using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;

namespace CourierKata.Services
{
    public interface ICostCalculator
    {
        CostEstimation Calculate(ParcelDimensions dimensions);
    }
}
