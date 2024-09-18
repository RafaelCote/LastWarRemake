using Units.Projectiles;
using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Shooting Arc", menuName = "Ability/Shooting Arc", order = 0)]
    public class ShootingArcProjectile : BaseAbility
    {
        [SerializeField] private ArcProjectile _projectile;

        private float _currentCooldown = 0.0f;
        
        public override void Use(UnitController owner)
        {
            if (owner.TryGetQuadraticCurveComponent(out var curveComponent))
            {
                _projectile.SetQuadraticCurve(curveComponent.Curve);
                _projectile.Launch(owner.GetAbilitySpawnPoint());
            }
            else
            {
                Debug.LogError($"Unit gameObject {owner.gameObject.name} is lacking a QuadraticCurveComponent");
            }
        }
    }
}