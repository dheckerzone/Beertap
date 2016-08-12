using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beertap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.WebApi.Hypermedia
{
    public class BeerStateProvider: BeerStateProvider<BeerDTO>
    {
        
    }

    public abstract class BeerStateProvider<TBeerResource> : ResourceStateProviderBase<TBeerResource, BeerState>
        where TBeerResource : IStatefulResource<BeerState>, IStatefulBeer
    {
        public override BeerState GetFor(TBeerResource resource)
        {
            return resource.BeerState;
        }
        protected override IDictionary<BeerState, IEnumerable<BeerState>> GetTransitions()
        {
            return new Dictionary<BeerState, IEnumerable<BeerState>>
            {
                {
                    BeerState.New, new[]
                    {
                        BeerState.New,
                        BeerState.GoingDown
                    }
                },
                {
                    BeerState.GoingDown, new[]
                    {
                        BeerState.GoingDown,
                        BeerState.AlmostEmpty
                    }
                },
                {
                    BeerState.AlmostEmpty, new[]
                    {
                        BeerState.AlmostEmpty,
                        BeerState.Dry
                    }
                },
                {
                    BeerState.Dry, new[]
                    {
                        BeerState.Dry,
                        BeerState.New
                    }
                },
            };
        }
        public override IEnumerable<BeerState> All
        {
            get { return EnumEx.GetValuesFor<BeerState>(); }
        }
    }
}