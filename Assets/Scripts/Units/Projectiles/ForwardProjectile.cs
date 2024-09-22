using System;
using UnityEngine;

namespace Units.Projectiles
{
    [CreateAssetMenu(fileName = "Forward Bullet", menuName = "Projectiles/Forward Bullet", order = 0)]
    public class ForwardProjectile : BaseProjectile
    {
        public override void Launch(Transform spawnPoint, Action<GameObject> projectileSpawnCallback)
        {
            var bullet = Instantiate(_prefab, spawnPoint.position, spawnPoint.rotation);
            projectileSpawnCallback?.Invoke(bullet.gameObject);
            bullet.Init(_bulletDamage);
            bullet.Launch(spawnPoint.forward, _bulletSpeed);
        }
    }
}