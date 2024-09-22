using UnityEngine;

namespace Units.Abilities
{
    public abstract class BaseAbility : ScriptableObject
    {
        public float Cooldown = 0.0f;

        public abstract void Use(UnitController owner);

        protected void InitializeDamageLayer(GameObject damageObject, int ownerLayer)
        {
            string layerNameDebug = LayerMask.LayerToName(ownerLayer);
            if (ownerLayer == LayerMask.NameToLayer("Player Units"))
                damageObject.layer = LayerMask.NameToLayer("Player Attacks");
            else if (ownerLayer == LayerMask.NameToLayer("Enemy Units"))
                damageObject.layer = LayerMask.NameToLayer("Enemy Attacks");
        }
    }
}