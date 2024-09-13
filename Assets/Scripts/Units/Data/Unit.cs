using Units.Abilities;
using UnityEngine;

namespace Units.Data
{
    [CreateAssetMenu(fileName = "Basic Unit", menuName = "Unit/Basic", order = 0)]
    public class Unit : ScriptableObject
    {
        public Mesh Mesh;
        public Material Material; 
        public BaseAbility AttackAbility;
        public int MaxHealth;
        public float MovementSpeed;
    }
}