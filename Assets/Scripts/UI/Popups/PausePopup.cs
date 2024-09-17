using GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class PausePopup : BasePopup
    {
        [SerializeField] private GameStateController gameStateController; 
        
        [SerializeField] private Button exitButton;
        [SerializeField] private Button continueButton;

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
            continueButton.onClick.AddListener(Resume);
            exitButton.onClick.AddListener(Quit);
        }

        private void Unsubscribe()
        {
            continueButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
        }

        private void Resume() => 
            gameStateController.ResumeGame();

        private void Quit() => 
            gameStateController.ExitToQuit();
    }
}