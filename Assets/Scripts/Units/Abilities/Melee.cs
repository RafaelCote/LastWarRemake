using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Melee", menuName = "Ability/Melee", order = 1)]
    public class Melee : BaseAbility
    {
        private float _currentCooldown = 0.0f;
        
        public override void Use(UnitController owner)
        {
            if (_currentCooldown <= 0.0f)
            {
                owner.Animate("Attack");
                owner.StartCoroutine(owner.ActivateHitBoxForSeconds(1.0f));
                _currentCooldown = Cooldown;
            }
                
            _currentCooldown -= Time.deltaTime;
        }
    }
}