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
        OfficeResourceDto UpdateOffice(OfficeEntityDto officeEntDto);
        TapResourceDto TapGet(int id, int officeid);
        ICollection<TapResourceDto> TapGetMany(int officeId);
        TapResourceDto TapCreate(TapEntityDto tapEntDto);
        KegResourceDto KegChange(KegEntityDto kegEntDto);
        KegResourceDto TapKegGet(int tapId, int officeId);
        CupResourceDto CupCreate(CupEntityDto cupEntDto);
    }
}