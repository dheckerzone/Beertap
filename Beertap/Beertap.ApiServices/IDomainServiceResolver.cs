﻿using System;
using Beertap.Services;

namespace Beertap.ApiServices
{
    public interface IDomainServiceResolver
    {
        IDomainService Resolve(Type requestedServiceType);

        TService Resolve<TService>()
            where TService : IDomainService;
    }
}

namespace Beertap.Services
{
    /// <summary> 
    /// Represents a specific domain service / repository used in IApiApplicationService implementations 
    /// </summary> 
    public interface IDomainService
    {
    }
}
