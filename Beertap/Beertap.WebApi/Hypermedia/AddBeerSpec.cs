using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;

namespace Beertap.WebApi.Hypermedia
{
    public class AddBeerSpec: SingleStateResourceSpec<AddBeer, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({OfficeId})/AddKeg");
        protected override IEnumerable<ResourceLinkTemplate<AddBeer>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, BeerSpec.Uri, c => c.OfficeId, c => c.Id);
        }

        public override IResourceStateSpec<AddBeer, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<AddBeer, int>
                  {
                      Links =
                      {
                        CreateLinkTemplate(LinkRelations.Beers.GetBeer, BeerSpec.Uri, c=> c.OfficeId, c=> c.Id)
                      },
                      Operations = new StateSpecOperationsSource<AddBeer, int>
                      {
                          InitialPost = ServiceOperations.Create
                      },
                  };
            }
        }
    }
}