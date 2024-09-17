namespace Enemies
{
    public class PatrolState : IEnemyState
    {
        private int _currentPatrolIndex;

        public void EnterState(EnemyController enemy)
        {
            _currentPatrolIndex = 0;
            SetNextPatrolPoint(enemy);
        }

        public void UpdateState(EnemyController enemy)
        {
            if (!enemy.NavMeshAgent.pathPending && enemy.NavMeshAgent.remainingDistance < 0.5f)
            {
                SetNextPatrolPoint(enemy);
            }
        }

        public void ExitState(EnemyController enemy)
        {

        }

        private void SetNextPatrolPoint(EnemyController enemy)
        {
            if (enemy.PatrolPoints.Length == 0) return;

            enemy.NavMeshAgent.destination = enemy.PatrolPoints[_currentPatrolIndex].position;
            _currentPatrolIndex = (_currentPatrolIndex + 1) % enemy.PatrolPoints.Length;
        }
    }
}