using System;
using Hero;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        public string itemName;

        protected abstract void OnCollect(HeroCollector collector);

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