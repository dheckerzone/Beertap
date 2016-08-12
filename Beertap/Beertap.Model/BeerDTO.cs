using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    public class BeerDTO: BeerBaseDTO, IStatefulResource<BeerState>, IIdentifiable<int>, IStatefulBeer
    {
        
    }
}
