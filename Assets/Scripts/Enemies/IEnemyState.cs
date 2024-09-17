﻿namespace Enemies
{
    public interface IEnemyState
    {
        void EnterState(EnemyController enemy);
        void UpdateState(EnemyController enemy);
        void ExitState(EnemyController enemy);
    }
}