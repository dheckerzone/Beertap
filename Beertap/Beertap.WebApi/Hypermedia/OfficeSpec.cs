using System.Collections.Generic;
using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.WebApi.Hypermedia
{
    public class OfficeSpec: SingleStateResourceSpec<Office, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({Id})");
        protected override IEnumerable<ResourceLinkTemplate<Office>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
            yield return CreateLinkTemplate(LinkRelations.Beer, BeerSpec.Uri.Many, c=> c.Id);
            yield return CreateLinkTemplate(LinkRelations.Beers.AddKeg, AddBeerSpec.Uri, c => c.Id);
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }
    }
}