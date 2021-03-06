﻿using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using Beertap.ApiServices.Security;

namespace Beertap.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeertapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeertapApiUser> apiUserInRequestStore)
            : base(new BeertapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeertapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeertapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}