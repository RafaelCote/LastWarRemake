using UnityEngine;

namespace Units.Abilities
{
    public abstract class BaseAbility : ScriptableObject
    {
        public float Cooldown = 0.0f;
        
        public abstract void Use(UnitController owner);
    }
}