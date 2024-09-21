using MrHatProduction.Tools.Components;
using ObstaclesSystem.Data.Obstacles;
using UnityEngine;

namespace ObstacleSystem
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(DamageableComponent))]
    public class ObstacleController : MonoBehaviour
    {
        [SerializeField] private BaseObstacle _obstacle = null;
        
        private HealthComponent _healthComponent = null;
        private DamageableComponent _damageableComponent = null;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _damageableComponent = GetComponent<DamageableComponent>();
        }

        private void Start()
        {
            _healthComponent.Init(_obstacle.StartingHealth);
            _damageableComponent.DamageReceived += DamageableComponent_DamageReceived;
        }

        private void DamageableComponent_DamageReceived(int healthAmount)
        {
            if (_obstacle.Mode == ObstacleMode.Increasing)
                _healthComponent.Heal(healthAmount);
            else if (_obstacle.Mode == ObstacleMode.Decreasing)
                _healthComponent.TakeDamage(healthAmount);
        }
    }
}