using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapV2.DTO
{
    /// <summary>
    /// Cup dto for entity
    /// </summary>
    public class CupEntityDto
    {
        /// <summary>
        /// identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// how much mulliliter is in cup
        /// </summary>
        public decimal Milliliters { get; set; }
        /// <summary>
        /// Tap the drink in cup is from
        /// </summary>
        public int TapId { get; set; }
    }

    /// <summary>
    /// cup dto for resource
    /// </summary>
    public class CupResourceDto
    {
        /// <summary>
        /// identification
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// how much mulliliter is in cup
        /// </summary>
        public decimal Milliliters { get; set; }
        /// <summary>
        /// flavor in cup
        /// </summary>
        public string Flavor { get; set; }
    }
}
