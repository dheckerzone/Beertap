using Beertap.Model;
using IQ.Platform.Framework.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertap.ApiServices
{
    public interface IAddBeerApiService: ICreateAResourceAsync<AddBeerDTO, int>
    {
    }
}
