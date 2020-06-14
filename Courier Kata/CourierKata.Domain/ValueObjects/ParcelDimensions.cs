namespace CourierKata.Domain.ValueObjects
{
    public class ParcelDimensions
    {
        public ParcelDimensions(
            double length,
            double height,
            double width)
        {
            Length = length;
            Height = height;
            Width = width;
        }

        public double Length { get; }

        public double Height { get; }

        public double Width { get; }
    }
}