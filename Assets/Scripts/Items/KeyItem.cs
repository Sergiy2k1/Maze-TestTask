using Hero;

namespace Items
{
    public class KeyItem : Item
    {
        public override void OnCollect(HeroCollector collector)
        {
            collector?.CollectItem(this);

            Destroy(gameObject);
        }
    }
}