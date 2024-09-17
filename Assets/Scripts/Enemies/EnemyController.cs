using GameLogic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameStateController gameStateController;
        [SerializeField] private Transform[] patrolPoints;
        
        private IEnemyState _currentState;
        private PatrolState _patrolState;
        private AggressiveState _aggressiveState;
        private PlayerDetection _playerDetection;
        
        private Transform _player;
        private NavMeshAgent _navMeshAgent;
        
        public Transform Player => _player;
        public Transform[] PatrolPoints => patrolPoints;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;
    

        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _playerDetection = GetComponent<PlayerDetection>();

            if (patrolPoints.Length == 0)
            {
                return;
            }

            _patrolState = new PatrolState();
            _aggressiveState = new AggressiveState();
            
            _playerDetection.OnPlayerDetected += HandlePlayerDetected;
            _playerDetection.OnPlayerLost += HandlePlayerLost;

            
            SwitchState(_patrolState);  
        }

        private void Update() => 
            _currentState?.UpdateState(this);
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                gameStateController.OnGameLose();
            }
        }
        
        private void SwitchState(IEnemyState newState)
        {
            _currentState?.ExitState(this);
            _currentState = newState;
            _currentState.EnterState(this);
        }

        private void HandlePlayerDetected() => 
            SwitchState(_aggressiveState);

        private void HandlePlayerLost() => 
            SwitchState(_patrolState);
    }
}
