using Audio;
using Const;
using Hero;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour, ICollectible
    {
        public abstract void OnCollect(HeroCollector collector);

        private void OnTriggerEnter(Collider other)
        {
            HeroCollector collector = other.GetComponent<HeroCollector>();
            if (collector != null)
            {
                OnCollect(collector);
            }
        }
    }
}