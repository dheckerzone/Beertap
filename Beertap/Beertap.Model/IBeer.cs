using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beertap.Model
{
    public interface IBeer
    {
        /// <summary>
        /// Unique Identifier for Beer
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Foreign Key Identifier for Office Id
        /// </summary>
        int OfficeId { get; set; }

        /// <summary>
        /// Brand of the Beer
        /// </summary>
        string Brand { get; set; }
        /// <summary>
        /// Size of beer in Milliliter
        /// </summary>
        int Milliliters { get; set; }
        /// <summary>
        /// State of the Beer Keg
        /// </summary>
        BeerState BeerState { get; set; }
    }
}
