using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal;
using BeerTapV2.Dal.Model;
using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository : IBeerTapRepository
    {
        public OfficeResourceDto FindOffice(int id)
        {
            var office = _context.Offices.Find(id);
            Dispose();
            return AutoMapper.Mapper.Map<Office, OfficeResourceDto>(office);
        }

        public ICollection<OfficeResourceDto> GetOffices()
        {
            var offices = _context.Offices.ToList();
            Dispose();
            //TODO: possible make a helper library and method caled map?
            return offices.Select(AutoMapper.Mapper.Map<Office, OfficeResourceDto>).ToList();
        }

        public OfficeResourceDto CreateOffice(OfficeEntityDto officeEntDto)
        {
            var officeEnt = AutoMapper.Mapper.Map<OfficeEntityDto, Office>(officeEntDto);
            _context.Offices.Add(officeEnt);
            SaveChanges();
            Dispose();
            return AutoMapper.Mapper.Map<Office, OfficeResourceDto>(officeEnt);

        }

        public OfficeResourceDto UpdateOffice(OfficeEntityDto officeEntDto)
        {
            var officeEnt = AutoMapper.Mapper.Map<OfficeEntityDto, Office>(officeEntDto);
            _context.Offices.Attach(officeEnt);
            var entry = _context.Entry(officeEnt);
            entry.Property(a => a.Name).IsModified = true;
            SaveChanges();
            Dispose();
            return AutoMapper.Mapper.Map<Office, OfficeResourceDto>(officeEnt);
        }

        public TapResourceDto TapGet(int id)
        {
            var tapEnt = _context.Taps.Find(id);
            var tapResDto = AutoMapper.Mapper.Map<Tap,TapResourceDto>(tapEnt);
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
