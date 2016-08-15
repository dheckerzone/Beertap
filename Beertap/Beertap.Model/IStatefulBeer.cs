namespace Beertap.Model
{
    public interface IStatefulBeer
    {
        BeerState BeerState { get; }
    }
}
