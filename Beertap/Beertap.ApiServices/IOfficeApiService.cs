using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public interface IOfficeApiService: IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>
    {
    }
}
