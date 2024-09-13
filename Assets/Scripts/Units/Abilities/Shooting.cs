using Units.Projectiles;
using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Shooting", menuName = "Ability/Shooting", order = 0)]
    public class Shooting : BaseAbility
    {
        [SerializeField] private BaseProjectile _projectile;

        private float _currentCooldown = 0.0f;
        
        public override void Use(UnitController owner)
        {
            if (_currentCooldown <= 0.0f)
            {
                _projectile.Launch(owner.GetAbilitySpawnPoint());
                _currentCooldown = Cooldown;
            }

            _currentCooldown -= Time.deltaTime;
        }
    }
}