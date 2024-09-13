using UnityEngine;

namespace Units.Projectiles
{
    public abstract class BaseProjectile : ScriptableObject
    {
        [SerializeField] protected BulletController _prefab;
        [SerializeField] protected int _bulletDamage = 0;
        [SerializeField] protected float _bulletSpeed = 1.0f;

        public abstract void Launch(Transform spawnPoint);
    }
}