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
    public class CupSpec : SingleStateResourceSpec<Cup, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Taps({TapId})/NewGlass");

        public override string EntrypointRelation => LinkRelations.TapResource.NewGlass;

        protected override IEnumerable<ResourceLinkTemplate<Cup>> Links()
        {
            yield return CreateLinkTemplate<CupLinksParametersSource>(
                CommonLinkRelations.Self, Uri, c => c.Parameters.OfficeId, c => c.Parameters.TapId);
            yield return CreateLinkTemplate<CupLinksParametersSource>(
                LinkRelations.Tap, TapSpec.Uri, x => x.Parameters.OfficeId, x => x.Parameters.TapId);
            yield return CreateLinkTemplate<CupLinksParametersSource>(
                LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.OfficeId);
        }

        public override IResourceStateSpec<Cup, NullState, int> StateSpec => new SingleStateSpec<Cup, int>
        {
            Links =
            {

            },
            Operations = new StateSpecOperationsSource<Cup, int>
            {
                InitialPost = ServiceOperations.Create
            }
        };
    }

}