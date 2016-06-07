using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.Dal.Model;

namespace BeerTapV2.Dal
{
    public class BeerTapContext : DbContext
    {
        public BeerTapContext(): base("BeerTap2")
        {
            //Database.SetInitializer<BeerTapContext>();
        }
        public DbSet<Office> Offices { get; set; }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<BeerTapContext>
    {
        protected override void Seed(BeerTapContext context)
        {
            context.Offices.Add(new Office
            {
                Name = "Vancouver"
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
