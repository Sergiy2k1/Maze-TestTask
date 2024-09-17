using System.Collections.Generic;
using Items;

namespace Hero
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public bool HasItem(Item item)
        {
            return _items.Contains(item);
        }

        public int GetItemCount<T>() where T : Items.Item
        {
            int count = 0;
            foreach (var i in _items)
            {
                if (i is T)
                {
                    count++;
                }
            }
            return count;
        }

        public List<T> GetItemsOfType<T>() where T : Items.Item
        {
            List<T> result = new List<T>();
            foreach (var i in _items)
            {
                if (i is T t)
                {
                    result.Add(t);
                }
            }
            return result;
        }
    }
}