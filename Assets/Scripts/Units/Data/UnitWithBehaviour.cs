using UnityEngine;

namespace Units.Data
{
    [CreateAssetMenu(fileName = "Behavioural Unit", menuName = "Unit/With Behaviour", order = 1)]
    public class UnitWithBehaviour : Unit
    {
        public Behaviours.BaseUnitBehaviour Behaviour;
    }
}