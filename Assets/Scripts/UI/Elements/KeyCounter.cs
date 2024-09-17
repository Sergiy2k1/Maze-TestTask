using Environment;
using Hero;
using Items;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public class KeyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private HeroCollector heroCollector;
        [SerializeField] private int totalKeys = 3;

        private void Start()
        {
            if (heroCollector == null)
            {
                return;
            }

            heroCollector.Inventory.OnInventoryChanged += UpdateCounter;
            UpdateCounter(); 
        }

        private void OnDestroy()
        {
            if (heroCollector != null)
            {
                heroCollector.Inventory.OnInventoryChanged -= UpdateCounter;
            }
        }

        private void UpdateCounter()
        {
            int keysCollected = heroCollector.Inventory.GetItemCount<KeyItem>();
            counterText.text = $"{keysCollected}/{totalKeys}";
        }
    }
}