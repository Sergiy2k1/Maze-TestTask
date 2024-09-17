namespace Enemies
{
    public class AggressiveState : IEnemyState
    {
        public void EnterState(EnemyController enemy)
        {
            enemy.NavMeshAgent.speed *= 1.5f;
            AttackPlayer(enemy);
        }

        public void UpdateState(EnemyController enemy)
        {
            AttackPlayer(enemy);
        }

        public void ExitState(EnemyController enemy)
        {
            enemy.NavMeshAgent.speed /= 1.5f; 
        }

        private void AttackPlayer(EnemyController enemy) => 
            enemy.NavMeshAgent.destination = enemy.Player.position;
    }
}