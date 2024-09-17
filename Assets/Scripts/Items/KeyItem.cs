using Hero;

namespace Items
{
    public class KeyItem : Item
    {
        protected override void OnCollect(HeroCollector collector)
        {
            if (collector != null)
            {
                collector.CollectItem(this);
            }

            // Звуковий ефект або анімація
            // AudioManager.Instance.Play("KeyCollectSound");

            Destroy(gameObject);
        }
    }
}