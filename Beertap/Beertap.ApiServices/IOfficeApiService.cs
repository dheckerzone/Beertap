using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public interface IOfficeApiService: IGetAResourceAsync<OfficeDTO, int>,
        IGetManyOfAResourceAsync<OfficeDTO, int>
    {
    }
}
