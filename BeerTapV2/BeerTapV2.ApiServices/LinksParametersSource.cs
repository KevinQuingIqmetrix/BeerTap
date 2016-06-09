namespace BeerTapV2.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {
        public LinksParametersSource(int companyId)
        {
            CompanyId = companyId;
        }

        public int CompanyId { get; private set; }
    }

    public class TapLinksParametersSource
    {
        public TapLinksParametersSource(int officeId)
        {
            OfficeId = officeId;
        }

        public int OfficeId { get; private set; }
    }
    public class KegLinksParametersSource
    {
        public KegLinksParametersSource(int officeId, int tapId)
        {
            OfficeId = officeId;
            TapId = tapId;
        }

        public int TapId { get; private set; }

        public int OfficeId { get; private set; }
    }
}