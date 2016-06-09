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

        public const string Tap = "iq:Tap";

        public class TapResource
        {
            public const string ChangeKeg = "iq:ChangeKeg";
        }
        
    }
}
