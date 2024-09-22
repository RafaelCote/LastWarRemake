using MrHatProduction.Tools.Components;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(MovementComponent))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed = 0.0f;

        private PlayerInputActions _playerInputActions = null;
        private MovementComponent _movementComponent = null;
        private bool _isMoving = false;
        
        public bool IsMoving => _isMoving;

        private void Awake()
        {
            _movementComponent = GetComponent<MovementComponent>();
        }

        private void Update()
        {
            Vector2 inputValue = _playerInputActions.Player.Move.ReadValue<Vector2>();
            var movement = new Vector3(inputValue.x, 0.0f, inputValue.y);
            
            _movementComponent.Move(movement, _movementSpeed);
            _isMoving = movement != Vector3.zero;
        }
        
        public void EnableInputs()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
        }
    }
}