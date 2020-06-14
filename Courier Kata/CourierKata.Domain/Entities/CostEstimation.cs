using System;
using System.Collections.Generic;
using System.Linq;

namespace CourierKata.Domain.Entities
{
    public class CostEstimation : IEquatable<CostEstimation>
    {
        public ICollection<Parcel> Parcels { get; } = new List<Parcel>();

        public decimal TotalCost { get; set; }

        public bool Equals(CostEstimation other)
        {
            return
                this.Parcels.SequenceEqual(other.Parcels) &&
                this.TotalCost == other.TotalCost;
        }
    }
}