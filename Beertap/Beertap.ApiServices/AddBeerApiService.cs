using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Beertap.Model;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.Common;
using System.Net;
using Beertap.Data;

namespace Beertap.ApiServices
{
    public class AddBeerApiService : IAddBeerApiService
    {
        public Task<ResourceCreationResult<AddBeer, int>> CreateAsync(AddBeer resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context
                            .UriParameters
                            .GetByName<int>("OfficeId")
                            .EnsureValue(() => context.CreateHttpResponseException<AddBeer>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));

            using (var ctx = new BeertapContext())
            {
                var newKeg = new Data.Beer
                {
                    Brand = resource.Brand,
                    Milliliters = resource.Milliliters,
                    OfficeId = officeId
                };

                ctx.Beer.Add(newKeg);

                ctx.SaveChanges();

                var beer = ctx.Beer.First(b => b.OfficeId == officeId && b.BeerId == newKeg.BeerId);

                var result = new AddBeer
                {
                    Id = beer.BeerId,
                    Brand = beer.Brand,
                    Milliliters = beer.Milliliters,
                    OfficeId = beer.OfficeId,
                    BeerState = Common.GetBeerState(beer.Milliliters)
                };

                return Task.FromResult(new ResourceCreationResult<AddBeer, int>(result));
            }
        }
    }
}
