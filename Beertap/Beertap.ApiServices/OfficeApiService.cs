using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Beertap.Data;
using Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace Beertap.ApiServices
{
    public class OfficeApiService: IOfficeApiService
    {
        public Task<Model.Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var office = ctx.Office.FirstOrDefault(o => o.OfficeId == id);

                var result = new Model.Office
                {
                    Id = office.OfficeId,
                    Location = office.Location
                };

                return Task.FromResult(result);
            }
        }

        public Task<IEnumerable<Model.Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var offices = ctx.Office.ToList();

                var results = new List<Model.Office>();

                offices.ForEach(
                    o=> 
                        results.Add(
                            new Model.Office
                            {
                                Id = o.OfficeId,
                                Location = o.Location
                            }));

                return Task.FromResult((IEnumerable<Model.Office>)results);
            }
        }
    }
}
