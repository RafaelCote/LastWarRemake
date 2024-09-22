using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(InventoryManager))]
    public class PlayerController : MonoBehaviour
    {
        public event Action PlayerDied;
        
        private PlayerMovement _playerMovement = null;
        private InventoryManager _inventoryManager = null;
        private float _delay = 0.0f;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _inventoryManager = GetComponent<InventoryManager>();
        }

        private void Start()
        {
            _inventoryManager.AllUnitLost += InventoryManager_OnAllUnitLost;
            
            _playerMovement.EnableInputs();
            _inventoryManager.SpawnUnit();
        }

        private void Update()
        {
            if (_playerMovement.IsMoving && _delay <= 0.0f)
            {
                _inventoryManager.MakeUnitsUseAbility();
                _delay = RateOfFire;
            }

            _delay -= Time.deltaTime;
        }

        private void InventoryManager_OnAllUnitLost()
        {
            PlayerDied?.Invoke();
        }

        private float RateOfFire => 1.0f / 6.0f;
    }
}