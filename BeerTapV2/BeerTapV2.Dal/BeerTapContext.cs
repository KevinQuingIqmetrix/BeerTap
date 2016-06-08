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
            Database.SetInitializer<BeerTapContext>(new Initializer());
        }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Tap> Taps { get; set; }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<BeerTapContext>
    {
        protected override void Seed(BeerTapContext context)
        {
            context.Offices.Add(new Office
            {
                Name = "Vancouver",
                Taps = new[] {new Tap(), }
            });
            context.Offices.Add(new Office
            {
                Name = "Regina",
                Taps = new[] { new Tap(), }
            });
            context.Offices.Add(new Office
            {
                Name = "Winnipeg",
                Taps = new[] { new Tap(), }
            });
            context.Offices.Add(new Office
            {
                Name = "Davidson (NC)",
                Taps = new[] { new Tap(), }
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
