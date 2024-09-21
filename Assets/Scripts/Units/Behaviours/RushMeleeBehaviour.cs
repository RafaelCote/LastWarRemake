using MrHatProduction.Tools.StateMachine;
using Units.Behaviours.States;
using UnityEngine;

namespace Units.Behaviours
{
    [CreateAssetMenu(fileName = "Rush Melee", menuName = "Unit/Behaviour/Rush Melee", order = 0)]
    public class RushMeleeBehaviour : BaseUnitBehaviour
    {
        public override void Init(UnitController owner)
        {
            var attackingState = new Attacking(owner);
            var movingState = new MovingToRange(owner.transform, UnitController.PlayerTransform, 1.5f);
            movingState.TargetReached += () => ChangeState(attackingState);
            
            _stateMachine = new FiniteStateMachine<BaseUnitBehaviour>();
            _stateMachine.Init(this, movingState);
            _stateMachine.AddTransition(movingState, attackingState);
        }

        public override void Act()
        {
            if (_stateMachine != null)
                _stateMachine.Update();
        }
    }
}