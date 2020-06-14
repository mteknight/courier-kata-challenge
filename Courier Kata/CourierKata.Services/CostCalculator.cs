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
                var parcel = GetParcel(dimensions);

                estimation.Parcels.Add(parcel);
                estimation.TotalCost += parcel.Cost;
            }

            return estimation;
        }

        private Parcel GetParcel(ParcelDimensions dimensions)
        {
            var parcelSize = GetParcelSize(dimensions);

            return _parcelRepository.Get(parcelSize);
        }

        private static Parcel.ParcelSize GetParcelSize(ParcelDimensions dimensions)
        {
            var largestDimension = GetLargestDimension(dimensions);
            var parcelSize = default(Parcel.ParcelSize);

            if (largestDimension < 10)
            {
                parcelSize = Parcel.ParcelSize.Small;
            }
            else if (largestDimension < 50)
            {
                parcelSize = Parcel.ParcelSize.Medium;
            }
            else if (largestDimension < 100)
            {
                parcelSize = Parcel.ParcelSize.Large;
            }

            return parcelSize;
        }

        private static double GetLargestDimension(ParcelDimensions dimensions)
        {
            var dimensionsArray = new[] { dimensions.Length, dimensions.Height, dimensions.Width };

            return dimensionsArray.Max();
        }
    }
}