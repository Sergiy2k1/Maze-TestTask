using UnityEngine;
using System;

namespace Enemies
{
    public class PlayerDetection : MonoBehaviour
    {
        [SerializeField] private float detectionRange = 10.0f;
        [SerializeField] private float fieldOfViewAngle = 120.0f; 

        private Transform _player;
        public event Action OnPlayerDetected;
        public event Action OnPlayerLost;

        private bool _isPlayerDetected;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update() => 
            DetectPlayer();

        private void DetectPlayer()
        {
            Vector3 directionToPlayer = (_player.position - transform.position).normalized;
            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

            // Перевірка чи гравець у зоні виявлення і чи знаходиться у полі зору
            if (distanceToPlayer <= detectionRange && angleToPlayer <= fieldOfViewAngle / 2)
            {
                if (!_isPlayerDetected)
                {
                    _isPlayerDetected = true;
                    OnPlayerDetected?.Invoke();  
                }
            }
            else
            {
                if (_isPlayerDetected)
                {
                    _isPlayerDetected = false;
                    OnPlayerLost?.Invoke();  
                }
            }
        }

      
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, detectionRange);
            
            Vector3 forward = transform.forward * detectionRange;
            Vector3 rightLimit = Quaternion.Euler(0, fieldOfViewAngle / 2, 0) * forward;
            Vector3 leftLimit = Quaternion.Euler(0, -fieldOfViewAngle / 2, 0) * forward;
            
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, rightLimit);
            Gizmos.DrawRay(transform.position, leftLimit);
        }
    }
}
