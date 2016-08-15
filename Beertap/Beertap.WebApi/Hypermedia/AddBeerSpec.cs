using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System.Collections.Generic;

namespace Beertap.WebApi.Hypermedia
{
    public class AddBeerSpec: SingleStateResourceSpec<AddBeerDTO, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({OfficeId})/AddKeg");
        protected override IEnumerable<ResourceLinkTemplate<AddBeerDTO>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, BeerSpec.Uri, c => c.OfficeId, c=> c.Id);
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Beers.AddKeg; }
        }

        public override IResourceStateSpec<AddBeerDTO, NullState, int> StateSpec
        {
            get
            {
                return
                  new SingleStateSpec<AddBeerDTO, int>
                  {
                      Links =
                      {
                        CreateLinkTemplate(LinkRelations.Beers.GetBeer, BeerSpec.Uri, c=> c.OfficeId, c=> c.Id)
                      },
                      Operations = new StateSpecOperationsSource<AddBeerDTO, int>
                      {
                          InitialPost = ServiceOperations.Create
                      },
                  };
            }
        }
    }
}