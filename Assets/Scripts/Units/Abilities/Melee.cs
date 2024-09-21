using MrHatProduction.Tools.Components;
using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Melee", menuName = "Ability/Melee", order = 0)]
    public class Melee : BaseAbility
    {
        public int Damage = 0;
        
        [SerializeField] private DamageComponent _colliderPrefab = null;

        private DamageComponent _damageColliderInstance = null;
        
        public override void Use(UnitController owner)
        {
            owner.Animate("Attack");
            var colliderSpawnPoint = owner.GetMeleeColliderSpawnPoint();
            _damageColliderInstance = Instantiate(_colliderPrefab, colliderSpawnPoint.position, colliderSpawnPoint.rotation);
            _damageColliderInstance.HitSomething += _ => DestroyColliderInstance();
            _damageColliderInstance.CollidedWithSomething += _ => DestroyColliderInstance();
            _damageColliderInstance.Init(Damage);
        }

        private void DestroyColliderInstance()
        {
            Destroy(_damageColliderInstance.gameObject);
        }
    }
}