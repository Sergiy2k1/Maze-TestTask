// PausedState.cs

using Audio;
using UI.Elements;
using UI.Popups;
using UnityEngine;

namespace GameLogic
{
    public class PausedState : IGameState
    {
        private readonly GameStateController _gameStateController;
        private readonly TimeCounter _timeCounter;
        private readonly PausePopup _pauseMenuUI;

        public bool IsInputAllowed => false;
        public bool IsGameActive => false;

        public PausedState(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
            _timeCounter = gameStateController.TimeCounter;
            _pauseMenuUI = gameStateController.PauseMenuUI;
        }

        public void EnterState()
        {
            AudioManager.Instance.StopSteps(); 
            _timeCounter.StopCounting();
            _pauseMenuUI.ShowView();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void ExitState()
        {
            _pauseMenuUI.HideView();
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameStateController.ChangeState(new PlayingState(_gameStateController));
            }
        }
    }
}