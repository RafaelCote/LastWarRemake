using MrHatProduction.Tools.StateMachine;
using UnityEngine;

namespace Units.Behaviours
{
    public abstract class BaseUnitBehaviour : ScriptableObject
    {
        protected FiniteStateMachine<BaseUnitBehaviour> _stateMachine = null;
        
        public abstract void Init(UnitController owner);
        public abstract void Act();

        public virtual void ChangeState(State<BaseUnitBehaviour> newState)
        {
            _stateMachine.TryChangeState(newState);
        }
    }
}