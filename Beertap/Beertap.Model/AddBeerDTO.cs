using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    public class AddBeerDTO: BeerBaseDTO, IStatelessResource, IIdentifiable<int>
    {
    }
}
