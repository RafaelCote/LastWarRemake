using MrHatProduction.Tools.Math;
using UnityEngine;

namespace Units.Projectiles
{
    [CreateAssetMenu(fileName = "Arc Projectile", menuName = "Projectiles/Arc Projectile", order = 2)]
    public class ArcProjectile : BaseProjectile
    {
        [SerializeField] private AnimationCurve _animationCurve = null;
        
        private QuadraticCurve _quadraticCurve;

        public override void Launch(Transform spawnPoint)
        {
            var bullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
            bullet.Init(_bulletDamage);
            bullet.Launch(_animationCurve, _quadraticCurve);
        }
        
        public void SetQuadraticCurve(QuadraticCurve quadraticCurve) => _quadraticCurve = quadraticCurve;
    }
}