﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Beertap.Data;
using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public class ReplaceBeerApiService: IReplaceBeerApiService
    {
        public Task<ReplaceBeerDTO> UpdateAsync(ReplaceBeerDTO resource, IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var existing = ctx.Beer.First(b => b.BeerId == resource.Id);

                existing.Milliliters = 4000;

                ctx.SaveChanges();

                resource.Milliliters = existing.Milliliters;

                resource.BeerState = BeerState.New;

                return Task.FromResult(resource);
            }
        }
    }
}
