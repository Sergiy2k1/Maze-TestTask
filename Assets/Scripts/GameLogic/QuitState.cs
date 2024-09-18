namespace GameLogic
{
    public class QuitState : IGameState
    {
        public bool IsGameActive => false;

        public void EnterState()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ExitState()
        {
        }

        public void UpdateState()
        {
        }
    }
}