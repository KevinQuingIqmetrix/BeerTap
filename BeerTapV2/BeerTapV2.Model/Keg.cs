using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.Model
{
    public class Keg : IIdentifiable<int>, IStatelessResource
    {
        public int Id { get; set; }
        public string Flavor { get; set; }
        public decimal Milliliters { get; set; }
        public decimal Capacity { get; set; }
        public decimal Threshold { get; set; }
    }
}
