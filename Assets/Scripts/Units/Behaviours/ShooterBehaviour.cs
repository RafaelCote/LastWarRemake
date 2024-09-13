using MrHatProduction.Tools.StateMachine;
using Units.Behaviours.States;
using UnityEngine;

namespace Units.Behaviours
{
    [CreateAssetMenu(fileName = "Shooter", menuName = "Unit/Behaviour/Shooter", order = 1)]
    public class ShooterBehaviour : BaseUnitBehaviour
    {
        public float RangeShoot = 3.0f;
        
        public override void Init(UnitController owner)
        {
            var attackingState = new Attacking(owner);
            var movingState = new MovingToRange(owner.transform, UnitController.PlayerTransform, RangeShoot);
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