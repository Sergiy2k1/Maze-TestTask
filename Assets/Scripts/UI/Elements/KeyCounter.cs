using Environment;
using Hero;
using Items;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Elements
{
    public class KeyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counterText;
        [SerializeField] private HeroCollector heroCollector;
        [SerializeField] private ExitEnvironment exitEnvironment;
         
        private int _requiredKeys ;

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
            _requiredKeys = exitEnvironment.RequiredKeys;
            int keysCollected = heroCollector.Inventory.GetItemCount<KeyItem>();
            counterText.text = $"{keysCollected}/{_requiredKeys}";
        }
    }
}