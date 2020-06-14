using CourierKata.Domain.Entities;

namespace CourierKata.Repositories
{
    public interface IParcelRepository
    {
        Parcel Get(Parcel.ParcelSize size);
    }
}