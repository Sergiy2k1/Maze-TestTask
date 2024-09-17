// QuitState.cs
using UnityEngine;

namespace GameLogic
{
    public class QuitState : IGameState
    {
        public bool IsInputAllowed => false;
        public bool IsGameActive => false;

        public void EnterState()
        {
            // Логіка виходу з гри
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void ExitState()
        {
            // Нічого не робимо, оскільки гра завершується
        }

        public void UpdateState()
        {
            // Нічого не робимо
        }
    }
}