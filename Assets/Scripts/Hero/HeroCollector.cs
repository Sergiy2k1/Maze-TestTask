using Items;
using UnityEngine;

namespace Hero
{
    public class HeroCollector : MonoBehaviour
    {
        public Inventory Inventory { get; private set; }
        
        private void Awake() => 
            Initial();

        private void Start() => 
            UpdateKeyUI();

        public void CollectItem(Item item)
        {
            Inventory.AddItem(item);

            if (item is KeyItem)
            {
                UpdateKeyUI();
            }
        }

        private void Initial() => 
            Inventory = new Inventory();

        private void UpdateKeyUI()
        {
            int keysCollected = Inventory.GetItemCount<KeyItem>();
            int totalKeys = FindObjectsOfType<KeyItem>().Length;
            
        }
    }
}