using System;

namespace CourierKata.Domain.Entities
{
    public class Parcel : IEquatable<Parcel>
    {
        public enum ParcelSize
        {
            Small,
            Medium,
            Large,
            XL
        }

        public ParcelSize Size { get; set; }

        public decimal Cost { get; set; }

        public bool Equals(Parcel other)
        {
            return
                this.Size == other.Size &&
                this.Cost == other.Cost;
        }
    }
}