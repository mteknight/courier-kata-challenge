using System;

namespace CourierKata.Domain.Entities
{
    public class CostEstimation : IEquatable<CostEstimation>
    {
        public CostEstimation(
            string size,
            decimal cost,
            decimal totalCost)
        {
            Size = size;
            Cost = cost;
            TotalCost = totalCost;
        }

        public string Size { get; }

        public decimal Cost { get; }

        public decimal TotalCost { get; }

        public bool Equals(CostEstimation other)
        {
            return
                this.Size == other.Size &&
                this.Cost == other.Cost &&
                this.TotalCost == other.TotalCost;
        }
    }
}