using Hero;

namespace Items
{
    public interface ICollectible
    {
        void OnCollect(HeroCollector collector);
    }
}