using Hero;
using TMPro;
using UnityEngine;

namespace UI.Elements
{
    public class KeyCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI counter;
        
        private HeroCollector _heroCollector;

        public void Construct(HeroCollector heroCollector)
        {
            _heroCollector = heroCollector;
        }
        private void UpdateCounter()
        {
            
        }
    }
}