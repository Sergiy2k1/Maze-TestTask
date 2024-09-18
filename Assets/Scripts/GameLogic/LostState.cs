// LostState.cs

using Audio;
using Const;
using UI.Elements;
using UI.Popups;
using UnityEngine;

namespace GameLogic
{
    public class LostState : IGameState
    {
        private readonly GameStateController _gameStateController;
        private readonly TimeCounter _timeCounter;
        private readonly LosePopup _loseMenuUI;
        
        public bool IsGameActive => false;

        public LostState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _timeCounter = gameStateController.TimeCounter;
            _loseMenuUI = gameStateController.LoseMenuUI;
        }

        public void EnterState()
        {
            _timeCounter.StopCounting();
            _loseMenuUI.ShowView();
            AudioManager.Instance.PlaySFX(AudioConst.Hit);
            AudioManager.Instance.StopSteps(); 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void ExitState()
        {
            _loseMenuUI.HideView();
        }

        public void UpdateState()
        {
            // Логіка оновлення для стану "Поразка", якщо необхідно
        }
    }
}