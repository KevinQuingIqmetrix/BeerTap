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
    /// <summary>
    /// keg resource
    /// </summary>
    public class Keg : IIdentifiable<int>, IStatelessResource
    {
        /// <summary>
        /// keg resource identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// flavor of keg
        /// </summary>
        public string Flavor { get; set; }
        /// <summary>
        /// how filled the keg is
        /// </summary>
        public decimal Milliliters { get; set; }//when replacing keg, it is always full
        /// <summary>
        /// limit of keg
        /// </summary>
        public decimal Capacity { get; set; }
        /// <summary>
        /// when the keg can be replaced
        /// </summary>
        public decimal ThresholdPercentage { get; set; }
    }
}
