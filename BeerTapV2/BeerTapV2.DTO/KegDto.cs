using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapV2.DTO
{
    public class KegResourceDto
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public decimal Capacity { get; set; }
        public decimal Milliliters { get; set; }
        public decimal ThresholdPercentage { get; set; }
    }

    public class KegEntityDto
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public decimal Capacity { get; set; }
        public decimal ThresholdPercentage { get; set; }
        public int TapId { get; set; }
    }
}
