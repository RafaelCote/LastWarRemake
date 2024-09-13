using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        
        //TODO: refactor using Movement Component.
        [SerializeField] private Transform _unitContainer = null;
        [SerializeField] private float _movementSpeed = 0.0f;

        private PlayerInputActions _playerInputActions = null;
        private bool _isMoving = false;
        
        public bool IsMoving => _isMoving;

        public void EnableInputs()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Player.Enable();
        }

        private void Update()
        {
            _isMoving = Move(_playerInputActions.Player.Move.ReadValue<Vector2>());
        }

        private bool Move(Vector2 inputValue)
        {
            var movement = new Vector3(inputValue.x, 0.0f, inputValue.y);
            _unitContainer.position += movement.normalized * _movementSpeed;
            return movement != Vector3.zero;
        }
    }
}