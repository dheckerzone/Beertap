namespace Beertap.Model
{
    public class BeerBaseDTO
    {
        public int Id { get; set; }

        public int OfficeId { get; set; }

        public string Brand { get; set; }
        public int Milliliters { get; set; }
        public BeerState BeerState { get; set; }
    }
}
