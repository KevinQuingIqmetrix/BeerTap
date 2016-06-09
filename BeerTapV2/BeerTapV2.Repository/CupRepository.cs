using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.DTO;
using Ploeh.AutoFixture;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository
    {
        public CupResourceDto CupCreate(CupEntityDto cupEntDto)
        {
            var tap = _context.Taps.FirstOrDefault(x => x.Id == cupEntDto.TapId);
            var cupResDto = new CupResourceDto();
            if (tap != null)
            {
                var keg = tap.Keg;
                var kegM = keg.Milliliters;
                var cupM = cupEntDto.Milliliters;

                //set return cup
                cupResDto.Flavor = keg.Flavor;
                cupResDto.Milliliters = cupM > kegM ? kegM : cupM;
                //set changes to keg
                keg.Milliliters = cupM > kegM ? 0 : kegM - cupM;

                SaveChanges();
                Dispose();
            }
            else throw new InvalidOperationException("No Tap with Id: " + cupEntDto.TapId);
            
            return cupResDto;
        }
    }
}
