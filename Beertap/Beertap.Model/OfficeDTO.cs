using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace Beertap.Model
{
    /// <summary>
    /// Data Transfer Object for Office
    /// </summary>
    public class OfficeDTO: IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for Office
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Location of the Office
        /// </summary>
        public string Location { get; set; }

    }
}
