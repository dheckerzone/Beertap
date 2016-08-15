using System.Collections.Generic;
using Beertap.Model;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.WebApi.Hypermedia
{
    public class BeerSpec : ResourceSpec<BeerDTO, BeerState, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Office({OfficeId})/Beer({Id})");
        protected override IEnumerable<ResourceLinkTemplate<BeerDTO>> Links()
        {
            yield return CreateLinkTemplate(CommonLinkRelations.Self, Uri, c => c.OfficeId, c => c.Id);
        }

        protected override IEnumerable<IResourceStateSpec<BeerDTO, BeerState, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<BeerDTO, BeerState, int>(BeerState.New)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Beers.GetBeer, Uri, c=> c.OfficeId, c=> c.Id)
                },
                Operations = new StateSpecOperationsSource<BeerDTO, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<BeerDTO, BeerState, int>(BeerState.GoingDown)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Beers.GetBeer, Uri, c=> c.OfficeId, c=> c.Id)
                },
                Operations = new StateSpecOperationsSource<BeerDTO, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<BeerDTO, BeerState, int>(BeerState.AlmostEmpty)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Beers.GetBeer, Uri, c=> c.OfficeId, c=> c.Id),
                    CreateLinkTemplate(LinkRelations.Beers.ReplaceKeg, ReplaceBeerSpec.Uri, c=> c.OfficeId, c=> c.Id)
                },
                Operations = new StateSpecOperationsSource<BeerDTO, int>()
                {
                    Get = ServiceOperations.Get,
                    Post = ServiceOperations.Update,
                    Put = ServiceOperations.Update
                }
            };
            yield return new ResourceStateSpec<BeerDTO, BeerState, int>(BeerState.Dry)
            {
                Links =
                {
                    CreateLinkTemplate(LinkRelations.Beers.ReplaceKeg, ReplaceBeerSpec.Uri, c=> c.OfficeId, c=> c.Id)
                },
                Operations = new StateSpecOperationsSource<BeerDTO, int>()
                {
                    Get = ServiceOperations.Get
                }
            };
        }

        public override string EntrypointRelation
        {
            get { return LinkRelations.Beer; }
        }
    }
}