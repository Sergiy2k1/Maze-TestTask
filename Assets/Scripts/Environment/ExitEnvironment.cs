using GameLogic;
using Hero;
using Items;
using UnityEngine;

namespace Environment
{
    public class ExitEnvironment : MonoBehaviour
    {
        [SerializeField] private int requiredKeys = 3;
        [SerializeField] private GameStateController gameStateController;

        public int RequiredKeys => requiredKeys;
        
        private bool _isUnlocked;

        private void OnTriggerEnter(Collider other)
        {
            HeroCollector collector = other.GetComponent<HeroCollector>();
            if (collector != null)
            {
                int keysCollected = collector.Inventory.GetItemCount<KeyItem>();

                if (keysCollected >= requiredKeys)
                {
                    Unlock();
                    gameStateController.OnGameWin();
                }
                else
                {
                    Debug.Log($"{keysCollected}/{requiredKeys}");
                }
            }
        }

        private void Unlock()
        {
            if (!_isUnlocked)
            {
                _isUnlocked = true;
                
                transform.position += new Vector3(0, 0, -2);
            }
        }
    }
}