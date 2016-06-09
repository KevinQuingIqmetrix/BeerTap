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
        public TapResourceDto TapGet(int id)
        {
            var tapEnt = _context.Taps.Find(id);
            var tapResDto = AutoMapper.Mapper.Map<Tap, TapResourceDto>(tapEnt);
            Dispose();
            return tapResDto;
        }

        public ICollection<TapResourceDto> TapGetMany(int officeId)
        {
            var tapEnts = _context.Offices.Find(officeId).Taps;
            var tapResDto = tapEnts.Select(AutoMapper.Mapper.Map<TapResourceDto>).ToList();
            Dispose();
            return tapResDto;
        }

        public TapResourceDto TapCreate(TapEntityDto tapEntDto)
        {
            var tapEnts = AutoMapper.Mapper.Map<Tap>(tapEntDto);
            _context.Taps.Add(tapEnts);
            SaveChanges();
            Dispose();
            return AutoMapper.Mapper.Map<TapResourceDto>(tapEnts);
        }
    }
}
