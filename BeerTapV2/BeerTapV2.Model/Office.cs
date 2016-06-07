using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.Model
{
    /// <summary>
    /// office resource
    /// </summary>
    public class Office : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// identification for office
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// name of office
        /// </summary>
        public string Name { get; set; }
    }
}
