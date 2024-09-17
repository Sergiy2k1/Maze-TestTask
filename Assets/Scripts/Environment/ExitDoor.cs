using GameLogic;
using Hero;
using Items;
using UnityEngine;

namespace Environment
{
    public class ExitDoor : MonoBehaviour
    {
        [SerializeField] private KeyItem[] keysForOpen;

        [SerializeField] private GameStateController gameStateController; 
        
        private int _requiredKeys;
        private bool _isUnlocked;

        private void Start() => 
            Initial();

        private void Initial() => 
            _requiredKeys = keysForOpen.Length;

        private void OnTriggerEnter(Collider other)
        {
            HeroCollector collector = other.GetComponent<HeroCollector>();

            if (collector != null)
            {
                int keysCollected = collector.Inventory.GetItemCount<KeyItem>();

                if (keysCollected >= _requiredKeys)
                {
                    Unlock();
                    gameStateController.OnGameWin();
                }
                else
                {
                    Debug.Log($"Not enough keys. Collected {keysCollected}/{_requiredKeys}");
                }
            }
        }

        private void Unlock()
        {
            if (!_isUnlocked)
            {
                _isUnlocked = true;
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.green;
                }
                Debug.Log("ExitDoor: Unlocked!");
            }
        }
    }
}