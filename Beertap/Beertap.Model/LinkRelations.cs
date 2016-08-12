namespace Beertap.Model
{
    /// <summary>
    /// iQmetrix link relation names
    /// </summary>
    public static class LinkRelations
    {
        /// <summary>
        /// link relation to describe the Identity resource.
        /// </summary>
        public const string SampleResource = "iq:SampleResource";

        public const string Office = "Office";

        public const string OfficeBeer = "OfficeBeer";

        public const string Beer = "Beer";

        public static class Beers
        {
            public const string ReplaceKeg = "ReplaceKeg";

            public const string GetBeer = "GetBeer";
        }

    }
}
