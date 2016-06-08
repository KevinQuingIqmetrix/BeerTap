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
            return AutoMapper.Mapper.Map<Office, OfficeResourceDto>(office);
        }

        public ICollection<OfficeResourceDto> GetOffices()
        {
            var offices = _context.Offices.ToList();
            //TODO: possible make a helper library and method caled map?
            return offices.Select(AutoMapper.Mapper.Map<Office, OfficeResourceDto>).ToList();
        }
    }
}
