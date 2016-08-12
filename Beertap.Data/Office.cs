using System.Collections.Generic;

namespace Beertap.Data
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Beer> Beers { get; set; }
    }
}
