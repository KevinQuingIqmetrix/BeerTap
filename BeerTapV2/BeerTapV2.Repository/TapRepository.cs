using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal.Model;
using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository
    {
        public TapResourceDto TapGet(int id, int officeid)
        {
            var tapEnt = _context.Taps.FirstOrDefault(x => x.Id == id&& x.Office.Id == officeid);
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
            var tapEnts = AutoMapper.Mapper.Map<TapEntityDto, Tap>(tapEntDto);
            var officeEnt = _context.Offices.FirstOrDefault(x => x.Id == tapEntDto.OfficeId);
            if (officeEnt == null)
            {
                return null;
            }
            _context.Taps.Add(tapEnts);
            //_context.ObjectStateManager
            var entry = _context.Entry(tapEnts.Office);
            entry.State = EntityState.Unchanged;
            SaveChanges();
            Dispose();
            return AutoMapper.Mapper.Map<TapResourceDto>(tapEnts);
        }
    }
}
