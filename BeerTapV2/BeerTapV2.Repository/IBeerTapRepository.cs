using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public interface IBeerTapRepository
    {
        OfficeResourceDto FindOffice(int id);
        void SaveChanges();
    }
}