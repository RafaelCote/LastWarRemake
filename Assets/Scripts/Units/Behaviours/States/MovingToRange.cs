using System;
using MrHatProduction.Tools.StateMachine;
using UnityEngine;

namespace Units.Behaviours.States
{
    public class MovingToRange : UpdatableState<BaseUnitBehaviour>
    {
        public event Action TargetReached; 
        
        private Transform _unitTransform = null;
        private Transform _targetTransform = null;
        private BaseUnitBehaviour _owner = null;
        private float _distanceFromTarget = 0.0f;

        public MovingToRange(Transform unitTransform, Transform targetTransform, float distanceFromTarget)
        {
            _unitTransform = unitTransform;
            _targetTransform = targetTransform;
            _distanceFromTarget = distanceFromTarget;
        }
        
        public override void Enter(BaseUnitBehaviour owner)
        {
            _owner = owner;
        }

        public override void Update()
        {
            var targetPositionXZ = new Vector3(_targetTransform.position.x, 0.0f, _targetTransform.position.z);
            var unitPositionXZ = new Vector3(_unitTransform.position.x, 0.0f, _unitTransform.position.z);
            
            if (Vector3.Distance(targetPositionXZ, unitPositionXZ) <= _distanceFromTarget)
                TargetReached?.Invoke();
            
            _unitTransform.GetComponent<UnitController>().Move(targetPositionXZ - unitPositionXZ);
        }

        public override void Exit() { }
    }
}