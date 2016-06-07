using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal;
using BeerTapV2.DTO;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository : IBeerTapRepository
    {
        public OfficeResourceDto FindOffice(int id)
        {
            var office = _context.Offices.Find(id);
            //TODO: add mapper for EntityDTO to resourceDTO 
            return new OfficeResourceDto
            {
                Id = office.Id,
                Name = office.Name
            };
        }
    }
}
