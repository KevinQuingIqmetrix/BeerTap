using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal.Model;
using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository
    {
        public KegResourceDto KegChange(KegEntityDto kegEntDto)
        {
            var tapId = kegEntDto.TapId;
            var kegEnt = AutoMapper.Mapper.Map<Keg>(kegEntDto);

            if (kegEnt != null)
            {
                var keg = _context.Taps.FirstOrDefault(x => x.Id == tapId);
                if (keg != null)
                    keg.Keg = kegEnt;
            }

            SaveChanges();
            Dispose();
            var kegResDto = AutoMapper.Mapper.Map<KegResourceDto>(kegEnt);
            return kegResDto;
        }

        public KegResourceDto TapKegGet(int tapId, int officeId)
        {
            var tapEnt = _context.Taps.Include("Keg").FirstOrDefault(x => x.Id == tapId && x.Office.Id == officeId);
            if (tapEnt != null)
            {
                var kegEnt = tapEnt.Keg;
                var kegResDto = AutoMapper.Mapper.Map<KegResourceDto>(kegEnt);
                return kegResDto;
            }
            else
            {
                return null;
            }
        }
    }
}
