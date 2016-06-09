using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapV2.ApiServices;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.WebApi.Hypermedia
{
    public class KegSpec : SingleStateResourceSpec<Keg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Taps({TapId})/ChangeKeg");

        public override string EntrypointRelation => LinkRelations.Keg;

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate<KegLinksParametersSource>(
                CommonLinkRelations.Self, Uri, x => x.Parameters.OfficeId, x => x.Parameters.TapId);
        }

        public override IResourceStateSpec<Keg, NullState, int> StateSpec => new SingleStateSpec<Keg, int>
        {
            Links =
            {

            },
            Operations = new StateSpecOperationsSource<Keg, int>
            {
                InitialPost = ServiceOperations.Create
            }
        };
    }
}