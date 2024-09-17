using System;
using System.Collections.Generic;
using Items;

namespace Hero
{
    public class Inventory : IInventory
    {
        private readonly List<ICollectible> _items = new List<ICollectible>();
        public event Action OnInventoryChanged;

        public void AddItem(ICollectible item)
        {
            _items.Add(item);
            OnInventoryChanged?.Invoke();
        }

        public int GetItemCount<T>() where T : ICollectible
        {
            int count = 0;
            foreach (var item in _items)
            {
                if (item is T)
                {
                    count++;
                }
            }
            return count;
        }
    }
}