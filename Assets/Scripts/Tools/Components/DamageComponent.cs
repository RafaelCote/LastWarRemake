using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    [RequireComponent(typeof(Collider))]
    public class DamageComponent : MonoBehaviour
    {
        public event Action<Collider> CollidedWithSomething;
        public event Action<Collision> HitSomething;
        
        private int _damage;

        private void OnDestroy()
        {
            CollidedWithSomething = null;
            HitSomething = null;
        }

        public void Init(int damage)
        {
            _damage = damage;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<DamageableComponent>(out var damageable)) 
                damageable.Hit(_damage);
            
            CollidedWithSomething?.Invoke(other);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<DamageableComponent>(out var damageable)) 
                damageable.Hit(_damage);
            
            HitSomething?.Invoke(other);
        }
    }
}