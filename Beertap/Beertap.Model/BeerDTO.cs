﻿using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    public class BeerDTO: BeerBaseDTO, IStatefulResource<BeerState>, IIdentifiable<int>, IStatefulBeer
    {
        
    }
}
