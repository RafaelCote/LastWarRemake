using UnityEngine;

namespace Units.Projectiles
{
    [CreateAssetMenu(fileName = "Forward Bullet", menuName = "Projectiles/Forward Bullet", order = 0)]
    public class ForwardProjectile : BaseProjectile
    {
        public override void Launch(Transform spawnPoint)
        {
            var bullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
            bullet.Init(_bulletDamage);
            bullet.Launch(spawnPoint.forward, _bulletSpeed);
        }
    }
}