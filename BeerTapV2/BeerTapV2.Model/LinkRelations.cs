namespace BeerTapV2.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string SampleResource = "iq:SampleResource";
        /// <summary>
        /// link relation to Office
        /// </summary>
        public const string Office = "iq:Offices";

        /// <summary>
        /// Tap link name
        /// </summary>
        public const string Tap = "iq:Tap";
        /// <summary>
        /// tapresource link class
        /// </summary>
        public class TapResource
        {
            /// <summary>
            /// change keg link name
            /// </summary>
            public const string ChangeKeg = "iq:ChangeKeg";

            /// <summary>
            /// Cup link name
            /// </summary>
            public const string NewGlass = "iq:NewGlass";
        }
        
    }
}
