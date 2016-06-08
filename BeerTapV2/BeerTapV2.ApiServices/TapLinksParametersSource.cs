namespace BeerTapV2.ApiServices
{
    public class TapLinksParametersSource
    {
        public TapLinksParametersSource(int officeId)
        {
            OfficeId = officeId;
        }

        public int OfficeId { get; private set; }
    }
}