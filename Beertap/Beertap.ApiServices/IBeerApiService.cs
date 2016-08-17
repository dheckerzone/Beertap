using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public interface IBeerApiService: IGetAResourceAsync<Beer, int>, 
        IUpdateAResourceAsync<Beer, int>, IGetManyOfAResourceAsync<Beer, int>, ICreateAResourceAsync<Beer, int>
    {
    }
}
