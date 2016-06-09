using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapV2.WebApi.Hypermedia
{
    public class OfficeSpec : SingleStateResourceSpec<Office, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({Id})");

        public override string EntrypointRelation => LinkRelations.Office;

        protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c=> c.Id);
            yield return CreateLinkTemplate(LinkRelations.Tap, TapSpec.Uri.Many, c=>c.Id);
        }

        public override IResourceStateSpec<Office, NullState, int> StateSpec => new SingleStateSpec<Office, int>
        {
            Links =
            {
                
            },
            Operations = new StateSpecOperationsSource<Office, int>
            {
                Get = ServiceOperations.Get,
                InitialPost = ServiceOperations.Create,
                Post = ServiceOperations.Update
            }
        };
    }
}