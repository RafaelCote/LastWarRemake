using UnityEngine;

namespace Units.Abilities
{
    [CreateAssetMenu(fileName = "Melee", menuName = "Ability/Melee", order = 0)]
    public class Melee : BaseAbility
    {
        private float _currentCooldown = 0.0f;
        
        public override void Use(UnitController owner)
        {
            owner.Animate("Attack");
            owner.StartCoroutine(owner.ActivateHitBoxForSeconds(1.0f));
        }
    }
}