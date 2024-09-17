using System;
using Items;

namespace Hero
{
    public interface IInventory
    {
        event Action OnInventoryChanged;
        void AddItem(ICollectible item);
        int GetItemCount<T>() where T : ICollectible;
    }
}