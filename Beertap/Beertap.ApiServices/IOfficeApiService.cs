﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public interface IOfficeApiService: IGetAResourceAsync<OfficeDTO, int>,
        IGetManyOfAResourceAsync<OfficeDTO, int>
    {
    }
}