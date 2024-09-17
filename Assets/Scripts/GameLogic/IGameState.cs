namespace GameLogic
{
    public interface IGameState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
        bool IsGameActive { get; }
    }
}