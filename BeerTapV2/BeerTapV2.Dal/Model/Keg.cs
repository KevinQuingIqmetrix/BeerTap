using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapV2.Dal.Model
{
    public class Keg
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public decimal Capacity { get; set; }
        public decimal Milliliters { get; set; }
        public decimal ThresholdPercentage { get; set; }
    }
}
