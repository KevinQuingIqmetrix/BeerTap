using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.Model
{
    /// <summary>
    /// Cup resource for taking from tap
    /// </summary>
    public class Cup: IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Identification for cup
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Milliliters of drink in cup
        /// </summary>
        public decimal Milliliters { get; set; }
        /// <summary>
        /// Flavor in cup
        /// </summary>
        public string Flavor { get; set; }

    }
}
