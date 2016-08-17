using System;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    /// <summary>
    /// Data Transfer Object for Viewing and Getting Beers
    /// </summary>
    public class BeerDTO : IBeerDTO, IStatefulResource<BeerState>, IIdentifiable<int>, IStatefulBeer
    {
        /// <summary>
        /// Unique Identifier for Beer
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key Identifier for Office Id
        /// </summary>
        public int OfficeId { get; set; }

        /// <summary>
        /// Brand of the Beer
        /// </summary>
        public string Brand { get; set; }
        
        /// <summary>
        /// Size of beer in Milliliter
        /// </summary>
        public int Milliliters { get; set; }

        /// <summary>
        /// State of the Beer Keg
        /// </summary>
        public BeerState BeerState { get; set; }

    }
}
