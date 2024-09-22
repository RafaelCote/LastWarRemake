using System;
using MrHatProduction.Tools.Components;
using ObstaclesSystem.Data.Obstacles;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ObstaclesSystem
{
    public class ObstacleController : MonoBehaviour
    {
        public event Action HasBeenTriggered;
        
        [SerializeField] private CollisionComponent _unitsCollisionComponent = null;
        [SerializeField] private HealthComponent _healthComponent = null;
        [SerializeField] private DamageableComponent _damageableComponent = null;
        
        private BaseObstacle _obstacle = null;

        private void OnEnable()
        {
            _damageableComponent.DamageReceived += DamageableComponent_DamageReceived;
            _unitsCollisionComponent.TriggerEntered += UnitsCollisionComponent_TriggerEntered;
        }

        private void OnDisable()
        {
            _damageableComponent.DamageReceived -= DamageableComponent_DamageReceived;
            _unitsCollisionComponent.TriggerEntered -= UnitsCollisionComponent_TriggerEntered;
        }

        public void Init(BaseObstacle obstacle)
        {
            _obstacle = obstacle;
            _healthComponent.Init(Random.Range(_obstacle.StartingHealthRange.x, _obstacle.StartingHealthRange.y));
        }

        private void DamageableComponent_DamageReceived(int healthAmount)
        {
            if (_obstacle.Mode == ObstacleMode.Increasing)
                _healthComponent.Heal(healthAmount);
            else if (_obstacle.Mode == ObstacleMode.Decreasing)
                _healthComponent.TakeDamage(healthAmount);
        }

        private void UnitsCollisionComponent_TriggerEntered(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player Units"))
            {
                var inventoryManager = FindObjectOfType<InventoryManager>();
                
                if (_healthComponent.CurrentHealth > 0)
                    inventoryManager.AddUnits(_healthComponent.CurrentHealth);
                else if (_healthComponent.CurrentHealth < 0)
                    inventoryManager.RemoveUnits(Mathf.Abs(_healthComponent.CurrentHealth));
                    
                HasBeenTriggered?.Invoke();
            }
        }
    }
}