using Units.Projectiles;
using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Shooting Forward", menuName = "Ability/Shooting Forward", order = 1)]
    public class ShootingForwardProjectile : BaseAbility
    {
        [SerializeField] private ForwardProjectile _projectile;
        
        public override void Use(UnitController owner)
        {
            _projectile.Launch(owner.GetAbilitySpawnPoint());
        }
    }
}