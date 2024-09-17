using Items;
using UnityEngine;

namespace Hero
{
    public class HeroCollector : MonoBehaviour
    {
        public IInventory Inventory { get; private set; }

        private void Awake()
        {
            Inventory = new Inventory();
        }

        public void CollectItem(ICollectible item)
        {
            Inventory.AddItem(item);
        }
    }
}