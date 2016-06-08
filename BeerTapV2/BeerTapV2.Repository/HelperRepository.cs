using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal;

namespace BeerTapV2.Repository
{
    public partial class BeerTapRepository
    {
        private readonly BeerTapContext _context;

        public BeerTapRepository(BeerTapContext context)
        {
            _context = context;
        }
        public BeerTapRepository()
        {
            _context = new BeerTapContext();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        //TODO: Implement DI and using on context at the same time
        public void Dispose()
        {
            _context.Dispose();
            //GC.SuppressFinalize(_context);
        }
    }
}
