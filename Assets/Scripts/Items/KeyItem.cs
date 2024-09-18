using Audio;
using Const;
using Hero;

namespace Items
{
    public class KeyItem : Item
    {
        public override void OnCollect(HeroCollector collector)
        {
            collector?.CollectItem(this);
            AudioManager.Instance.PlaySFX(AudioConst.TakeKey);
            Destroy(gameObject);
        }
    }
}