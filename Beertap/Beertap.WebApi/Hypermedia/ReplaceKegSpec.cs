using System.Collections.Generic;
using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.WebApi.Hypermedia
{
    public class ReplaceKegSpec: SingleStateResourceSpec<ReplaceBeer, int>
    {
        //public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/Beers(Id)/ReplaceKeg");
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create( BeerSpec.Uri + "/ReplaceKeg");

        protected override IEnumerable<ResourceLinkTemplate<ReplaceBeer>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        }

        public override IResourceStateSpec<ReplaceBeer, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<ReplaceBeer, int>
                  {
                      Links =
                      {
                        CreateLinkTemplate(LinkRelations.Beers.GetBeer, BeerSpec.Uri, c=> c.OfficeId, c=> c.Id)  
                      },
                      Operations = new StateSpecOperationsSource<ReplaceBeer, int>
                      {
                          Post = ServiceOperations.Update
                      },
                  };
            }
        }
    }
}