using System.Collections.Generic;

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
                var parcel = _parcelRepository.Get(Parcel.ParcelSize.Small);

                estimation.Parcels.Add(parcel);
                estimation.TotalCost += parcel.Cost;
            }

            return estimation;
        }
    }
}