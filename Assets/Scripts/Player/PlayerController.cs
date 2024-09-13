using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement),
                      typeof(InventoryManager))]
    public class PlayerController : MonoBehaviour
    {
        public event Action PlayerDied;
        
        private PlayerMovement _playerMovement = null;
        private InventoryManager _inventoryManager = null;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _inventoryManager = GetComponent<InventoryManager>();
            
            _inventoryManager.AllUnitLost += InventoryManager_OnAllUnitLost;
        }

        private void Start()
        {
            _playerMovement.EnableInputs();
            _inventoryManager.SpawnUnit();
        }

        private void Update()
        {
            if (_playerMovement.IsMoving)
            {
                _inventoryManager.MakeUnitsUseAbility();
            }
        }

        private void InventoryManager_OnAllUnitLost()
        {
            PlayerDied?.Invoke();
        }
    }
}