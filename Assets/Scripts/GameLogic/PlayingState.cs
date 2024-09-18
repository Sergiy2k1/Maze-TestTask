// PlayingState.cs
using UI.Elements;
using UI.Popups;
using UnityEngine;

namespace GameLogic
{
    public class PlayingState : IGameState
    {
        private readonly GameStateController _gameStateController;
        private readonly TimeCounter _timeCounter;
        private readonly PausePopup _pauseMenuUI;
        private readonly WinPopup _winMenuUI;
        private readonly LosePopup _loseMenuUI;

        public bool IsInputAllowed => true;
        public bool IsGameActive => true;

        public PlayingState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _timeCounter = gameStateController.TimeCounter;
            _pauseMenuUI = gameStateController.PauseMenuUI;
            _winMenuUI = gameStateController.WinMenuUI;
            _loseMenuUI = gameStateController.LoseMenuUI;
        }

        public void EnterState()
        {
            _timeCounter.PlayTimer();
            _pauseMenuUI.HideView();
            _winMenuUI.HideView();
            _loseMenuUI.HideView();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ExitState()
        {
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameStateController.ChangeState(new PausedState(_gameStateController));
            }
        }
    }
}