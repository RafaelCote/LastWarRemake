using MrHatProduction.Tools.StateMachine;
using UnityEngine;

namespace Units.Behaviours.States
{
    public class Attacking : UpdatableState<BaseUnitBehaviour>
    {
        private UnitController _unitController;
        private float _cooldown = 0.0f;
        
        public Attacking(UnitController unitController)
        {
            _unitController = unitController;
        }
        
        public override void Enter(BaseUnitBehaviour owner)
        {
            _unitController.UseAbility();
            _cooldown = _unitController.GetAbilityCooldown();
        }
        
        public override void Update()
        {
            if (_cooldown <= 0.0f)
            {
                _unitController.UseAbility();
                _cooldown = _unitController.GetAbilityCooldown();
            }

            _cooldown -= Time.deltaTime;
        }

        public override void Exit() { }
    }
}