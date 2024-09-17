using UI;
using UI.Elements;
using UI.Popups;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public enum GameState
    {
        Playing,
        Paused,
        Won,
        Lost,
        Quit 
    }

    public class GameStateController : MonoBehaviour
    { 
        [SerializeField] private TimeCounter timeCounter;
        
        [SerializeField] private PausePopup pauseMenuUI;
        [SerializeField] private WinPopup winMenuUI;
        [SerializeField] private LosePopup loseMenuUI;

        private GameState _currentState;
        
        public GameState CurrentState => _currentState;
        

        private void Start()
        {
            EnterState(GameState.Playing);
        }

        private void Update()
        {
            HandlePauseInput();
        }

        public void ChangeState(GameState newState)
        {
            ExitState(_currentState);
            _currentState = newState;
            EnterState(_currentState);
        }

        private void EnterState(GameState state)
        {
            switch (state)
            {
                case GameState.Playing:
                    timeCounter.PlayTimer();
                    pauseMenuUI.HideView();
                    winMenuUI.HideView();
                    loseMenuUI.HideView();
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;

                case GameState.Paused:
                    timeCounter.StopCounting(); 
                    if (pauseMenuUI != null) pauseMenuUI.ShowView();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;

                case GameState.Won:
                    winMenuUI.ShowView();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    timeCounter.StopCounting(); 
                    break;

                case GameState.Lost:
                    if (loseMenuUI != null) loseMenuUI.ShowView();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    timeCounter.StopCounting(); 
                    break;

                case GameState.Quit: 
                    QuitGame();
                    break;
            }
        }

        private void ExitState(GameState state)
        {
            switch (state)
            {
                case GameState.Playing:
                    break;

                case GameState.Paused:
                    if (pauseMenuUI != null) pauseMenuUI.HideView();
                    break;

                case GameState.Won:
                    if (winMenuUI != null) winMenuUI.HideView();
                    break;

                case GameState.Lost:
                    if (loseMenuUI != null) loseMenuUI.HideView();
                    break;
            }
        }

        private void HandlePauseInput()
        {
            if (_currentState == GameState.Playing && Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeState(GameState.Paused);
            }
            else if (_currentState == GameState.Paused && Input.GetKeyDown(KeyCode.Escape))
            {
                ChangeState(GameState.Playing);
            }
        }

        public void OnGameWin()
        {
            if (_currentState != GameState.Won)
            {
                ChangeState(GameState.Won);
            }
        }

        public void OnGameLose()
        {
            if (_currentState != GameState.Lost)
            {
                ChangeState(GameState.Lost);
            }
        }

        public void ResumeGame()
        {
            if (_currentState == GameState.Paused)
            {
                ChangeState(GameState.Playing);
            }
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            _currentState = GameState.Playing;
            timeCounter.ResetTime();
        }

        private void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        // Метод для зміни стану на Quit
        public void ExitToQuit()
        {
            ChangeState(GameState.Quit);
        }
    }
}
