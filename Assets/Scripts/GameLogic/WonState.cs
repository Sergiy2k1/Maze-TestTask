// WonState.cs
using UI.Elements;
using UI.Popups;
using UnityEngine;

namespace GameLogic
{
    public class WonState : IGameState
    {
        private readonly GameStateController _gameStateController;
        private readonly TimeCounter _timeCounter;
        private readonly WinPopup _winMenuUI;

        public bool IsInputAllowed => false;
        public bool IsGameActive => false;

        public WonState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _timeCounter = gameStateController.TimeCounter;
            _winMenuUI = gameStateController.WinMenuUI;
        }

        public void EnterState()
        {
            _timeCounter.StopCounting();
            _winMenuUI.ShowView();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void ExitState()
        {
            _winMenuUI.HideView();
        }

        public void UpdateState()
        {
            // Логіка оновлення для стану "Перемога", якщо необхідно
        }
    }
}