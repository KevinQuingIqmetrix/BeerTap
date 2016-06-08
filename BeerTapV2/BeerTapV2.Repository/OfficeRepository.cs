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
    }
}
