using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.WebApi.Hypermedia
{
    public class OfficeSpec: SingleStateResourceSpec<OfficeDTO, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({Id})");
        protected override IEnumerable<ResourceLinkTemplate<OfficeDTO>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.Id);
            yield return CreateLinkTemplate(LinkRelations.Beer, BeerSpec.Uri.Many, c=> c.Id);
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }
    }
}