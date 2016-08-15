using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Beertap.Data;
using Beertap.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public class BeerApiService: IBeerApiService
    {
        public Task<BeerDTO> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context
                            .UriParameters
                            .GetByName<int>("OfficeId")
                            .EnsureValue(() => context.CreateHttpResponseException<BeerDTO>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));

            using (var ctx = new BeertapContext())
            {
                BeerDTO result = GetBeerInfo(id, officeId, ctx);

                return Task.FromResult(result);
            }
        }

        public Task<BeerDTO> UpdateAsync(BeerDTO resource, IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var existing = ctx.Beer.First(b => b.BeerId == resource.Id);

                existing.Milliliters -= resource.Milliliters;

                ctx.SaveChanges();

                resource.Milliliters = existing.Milliliters;

                resource.BeerState = Common.GetBeerState(resource.Milliliters);

                return Task.FromResult(resource);
            }
        }

        public Task<IEnumerable<BeerDTO>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context
                            .UriParameters
                            .GetByName<int>("OfficeId")
                            .EnsureValue(() => context.CreateHttpResponseException<BeerDTO>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));

            using (var ctx = new BeertapContext())
            {
                var beer = ctx.Beer.Where(b => b.OfficeId == officeId).ToList();

                var result = new List<BeerDTO>();

                beer.ForEach(b => {
                    result.Add(
                        new BeerDTO
                        {
                            Id = b.BeerId,
                            Brand = b.Brand,
                            Milliliters = b.Milliliters,
                            OfficeId = b.OfficeId,
                            BeerState = Common.GetBeerState(b.Milliliters)
                        });
                });

                return Task.FromResult(result.AsEnumerable());
            }
        }

        public Task<ResourceCreationResult<BeerDTO, int>> CreateAsync(BeerDTO resource, IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var beer = new Beer
                {
                    Brand = resource.Brand,
                    Milliliters = resource.Milliliters,
                    OfficeId = resource.OfficeId
                };

                ctx.Beer.Add(beer);

                ctx.SaveChanges();

                var result = GetBeerInfo(beer.BeerId, beer.OfficeId, ctx);

                return Task.FromResult(new ResourceCreationResult<BeerDTO, int>(result));
            }
        }

        private BeerDTO GetBeerInfo(int id, int officeId, BeertapContext ctx)
        {
            var beer = ctx.Beer.First(b => b.OfficeId == officeId && b.BeerId == id);

            var result = new BeerDTO
            {
                Id = beer.BeerId,
                Brand = beer.Brand,
                Milliliters = beer.Milliliters,
                OfficeId = beer.OfficeId,
                BeerState = Common.GetBeerState(beer.Milliliters)
            };
            return result;
        }
    }
}
