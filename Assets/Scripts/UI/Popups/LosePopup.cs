using GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class LosePopup : BasePopup
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button restartButton;

        private void OnEnable() => 
            Subscription();

        private void OnDisable() => 
            Unsubscribe();
        
        public override void ShowView()
        {
            base.ShowView();
        }

        public override void HideView()
        {
            base.HideView();
        }
        private void Subscription()
        {
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Quit);
        }

        private void Unsubscribe()
        {
            restartButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }

        private void Restart() => 
            gameStateController.RestartGame();

        private void Quit() => 
            gameStateController.ExitToQuit();
    }
}