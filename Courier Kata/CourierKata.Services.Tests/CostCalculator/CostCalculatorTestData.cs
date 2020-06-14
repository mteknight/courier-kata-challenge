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
                new object[] {new ParcelDimensions(1, 1, 1), CreateCostEstimation(SmallParcel, 3m)},
                new object[] {new ParcelDimensions(9, 10, 9), CreateCostEstimation(MediumParcel, 8m)},
                new object[] {new ParcelDimensions(49, 50, 49), CreateCostEstimation(LargeParcel, 15m)},
                new object[] {new ParcelDimensions(99, 100, 99), CreateCostEstimation(XLParcel, 25m)},
            };

        public static Parcel SmallParcel => new Parcel { Size = Parcel.ParcelSize.Small, Cost = 3m };

        public static Parcel MediumParcel => new Parcel { Size = Parcel.ParcelSize.Medium, Cost = 8m };

        public static Parcel LargeParcel => new Parcel { Size = Parcel.ParcelSize.Large, Cost = 15m };

        public static Parcel XLParcel => new Parcel { Size = Parcel.ParcelSize.XL, Cost = 25m };

        private static CostEstimation CreateCostEstimation(
            Parcel parcel,
            decimal parcelCost)
        {
            var estimation = new CostEstimation();
            estimation.Parcels.Add(parcel);
            estimation.TotalCost = parcelCost;

            return estimation;
        }
    }
}