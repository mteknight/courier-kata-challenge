using System.Collections.Generic;
using System.Linq;

using CourierKata.Domain.Entities;
using CourierKata.Domain.ValueObjects;
using CourierKata.Repositories;

namespace CourierKata.Services
{
    public class CostCalculator : ICostCalculator
    {
        private readonly IParcelRepository _parcelRepository;

        public CostCalculator(
            IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public CostEstimation Calculate(IEnumerable<ParcelDimensions> parcelDimensions)
        {
            var estimation = new CostEstimation();

            foreach (var dimensions in parcelDimensions)
            {
                var dimensionsArray = new[] { dimensions.Length, dimensions.Height, dimensions.Width };
                var largestDimension = dimensionsArray.Max();
                var parcelSize = Parcel.ParcelSize.Small;

                if (largestDimension >= 10 && largestDimension < 50)
                {
                    parcelSize = Parcel.ParcelSize.Medium;
                }

                var parcel = _parcelRepository.Get(parcelSize);

                estimation.Parcels.Add(parcel);
                estimation.TotalCost += parcel.Cost;
            }

            return estimation;
        }
    }
}