using System;
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
    public class OfficeApiService: IOfficeApiService
    {
        public Task<OfficeDTO> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var office = ctx.Office.FirstOrDefault(o => o.OfficeId == id);

                var result = new OfficeDTO
                {
                    Id = office.OfficeId,
                    Location = office.Location
                };

                return Task.FromResult(result);
            }
        }

        public Task<IEnumerable<OfficeDTO>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            using (var ctx = new BeertapContext())
            {
                var offices = ctx.Office.ToList();

                var results = new List<OfficeDTO>();

                offices.ForEach(
                    o=> 
                        results.Add(
                            new OfficeDTO
                            {
                                Id = o.OfficeId,
                                Location = o.Location
                            }));

                return Task.FromResult((IEnumerable<OfficeDTO>)results);
            }
        }
    }
}
