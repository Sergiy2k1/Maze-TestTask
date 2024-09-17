using GameLogic;
using UnityEngine;

namespace CameraLogic
{
    public class CameraController : MonoBehaviour
    {
        private const string AxisMouseX = "Mouse X";
        private const string AxisMouseY = "Mouse Y";
        
        [SerializeField] private GameStateController gameStateController;
        
        [SerializeField] private float sensitivity = 2.0f; 
        [SerializeField] private  float maxYAngle = 80.0f; 
    
        private float _rotationX;

        private void Update() => 
            HandleCameraRotation();

        private void HandleCameraRotation()
        {
            if (gameStateController.CurrentState != GameState.Playing)
                return;
            
            float mouseX = Input.GetAxis(AxisMouseX);
            float mouseY = Input.GetAxis(AxisMouseY);
            
            transform.parent.Rotate(Vector3.up * mouseX * sensitivity);
            
            _rotationX -= mouseY * sensitivity;
            _rotationX = Mathf.Clamp(_rotationX, -maxYAngle, maxYAngle);
            transform.localRotation = Quaternion.Euler(_rotationX, 0.0f, 0.0f);
        }
    }
}
