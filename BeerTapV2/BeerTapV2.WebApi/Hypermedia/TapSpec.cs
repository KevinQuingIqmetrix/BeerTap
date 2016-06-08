using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapV2.ApiServices;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.WebApi.Hypermedia
{
    public class TapSpec: ResourceSpec<Tap,TapState,int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/Taps({Id})");
        public override string EntrypointRelation => LinkRelations.Tap;

        protected override IEnumerable<ResourceLinkTemplate<Tap>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
            yield return CreateLinkTemplate<TapLinksParametersSource>(CommonLinkRelations.Self, OfficeSpec.Uri, c => c.Parameters.OfficeId);
        }

        protected override IEnumerable<IResourceStateSpec<Tap, TapState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<Tap, TapState, int>(TapState.New)
            {
                Links = {},
                Operations = new StateSpecOperationsSource<Tap, int>()
                {
                    Get = ServiceOperations.Get,
                    InitialPost = ServiceOperations.Create
                }
            };
        }
    }
}