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
        public DbSet<Keg> Kegs { get; set; }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<BeerTapContext>
    {
        protected override void Seed(BeerTapContext context)
        {
            context.Offices.Add(new Office
            {
                Name = "Vancouver",
                Taps = new[] {
                    new Tap {
                        Keg = new Keg
                        {
                            Capacity = 10000,
                            Flavor = "Beer",
                            Milliliters = 10000,
                            ThresholdPercentage = 10
                        }
                    },
                }
            });
            context.Offices.Add(new Office
            {
                Name = "Regina",
                Taps = new[] {
                    new Tap {
                        Keg = new Keg
                        {
                            Capacity = 10000,
                            Flavor = "Cuervo",
                            Milliliters = 7001,
                            ThresholdPercentage = 10
                        }
                    },
                }
            });
            context.Offices.Add(new Office
            {
                Name = "Winnipeg",
                Taps = new[] {
                    new Tap {
                        Keg = new Keg
                        {
                            Capacity = 10000,
                            Flavor = "Red Horse",
                            Milliliters = 8000,
                            ThresholdPercentage = 10
                        }
                    },
                }
            });
            context.Offices.Add(new Office
            {
                Name = "Davidson (NC)",
                Taps = new[] {
                    new Tap {
                        Keg = new Keg
                        {
                            Capacity = 15000,
                            Flavor = "Cola",
                            Milliliters = 15000,
                            ThresholdPercentage = 7.5m
                        }
                    },
                }
            });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
