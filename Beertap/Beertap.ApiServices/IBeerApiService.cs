using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public interface IBeerApiService: IGetAResourceAsync<BeerDTO, int>, 
        IUpdateAResourceAsync<BeerDTO, int>, IGetManyOfAResourceAsync<BeerDTO, int>, ICreateAResourceAsync<BeerDTO, int>
    {
    }
}
