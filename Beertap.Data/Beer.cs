namespace Beertap.Data
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Brand { get; set; }

        public int Milliliters { get; set; }

        public int OfficeId { get; set; }
        public virtual  Office Office { get; set; }

    }
}
