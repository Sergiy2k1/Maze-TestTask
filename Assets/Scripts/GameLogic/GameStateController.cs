// GameStateController.cs

using UI.Elements;
using UI.Popups;
using UnityEngine;

namespace GameLogic
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private TimeCounter timeCounter;
        [SerializeField] private PausePopup pauseMenuUI;
        [SerializeField] private WinPopup winMenuUI;
        [SerializeField] private LosePopup loseMenuUI;

        private IGameState _currentState;

        public TimeCounter TimeCounter => timeCounter;
        public PausePopup PauseMenuUI => pauseMenuUI;
        public WinPopup WinMenuUI => winMenuUI;
        public LosePopup LoseMenuUI => loseMenuUI;
        
        public bool IsGameActive()
        {
            return _currentState?.IsGameActive ?? false;
        }

        private void Start()
        {
            ChangeState(new PlayingState(this));
        }

        private void Update()
        {
            _currentState?.UpdateState();
        }

        public void ChangeState(IGameState newState)
        {
            _currentState?.ExitState();
            _currentState = newState;
            _currentState?.EnterState();
        }

        public void OnGameWin()
        {
            if (!(_currentState is WonState))
            {
                ChangeState(new WonState(this));
            }
        }

        public void OnGameLose()
        {
            if (!(_currentState is LostState))
            {
                ChangeState(new LostState(this));
            }
        }

        public void ResumeGame()
        {
            if (_currentState is PausedState)
            {
                ChangeState(new PlayingState(this));
            }
        }

        public void RestartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            ChangeState(new PlayingState(this));
            timeCounter.ResetTime();
        }

        public void ExitToQuit()
        {
            ChangeState(new QuitState());
        }
    }
}
