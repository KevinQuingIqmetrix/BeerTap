using System.Collections.Generic;
using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public interface IBeerTapRepository
    {
        OfficeResourceDto FindOffice(int id);
        void SaveChanges();
        ICollection<OfficeResourceDto> GetOffices();
        OfficeResourceDto CreateOffice(OfficeEntityDto officeEntDto);
    }
}