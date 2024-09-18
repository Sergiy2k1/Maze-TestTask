using Audio;
using Const;
using GameLogic;
using UnityEngine;

namespace Hero
{
    public class HeroMove : MonoBehaviour
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        [SerializeField] private GameStateController gameStateController;
        
        [SerializeField] private float moveSpeed = 5.0f;
        [SerializeField] private float sprintMultiplier = 2.0f; 
        [SerializeField] private float gravity = 9.81f; 

        private CharacterController _controller;
        
        private bool _isMoving; 
        
        private void Start() => 
            Initial();

        private void Update() => 
            Move();

        private void Initial()
        {
            _controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Move()
        {
            if (!gameStateController.IsGameActive())
                return;
            
            float horizontalInput = Input.GetAxis(HorizontalAxis);
            float verticalInput = Input.GetAxis(VerticalAxis);

            Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
            
            if (moveDirection.magnitude > 1)
            {
                moveDirection.Normalize();
            }

            bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            
            float currentSpeed = moveSpeed;
            if (isSprinting)
            {
                currentSpeed *= sprintMultiplier;
            }
            
            moveDirection.y -= gravity * Time.deltaTime;
            
            _controller.Move(moveDirection * currentSpeed * Time.deltaTime);
            
            if (moveDirection.magnitude > 0.1f && _controller.isGrounded)
            {
                if (!_isMoving)
                {
                    _isMoving = true;
                    AudioManager.Instance.PlaySteps(AudioConst.Steps); 
                }
            }
            else
            {
                if (_isMoving)
                {
                    _isMoving = false;
                    AudioManager.Instance.StopSteps(); 
                }
            }
        }
    }
}
