using MrHatProduction.Tools.Components;
using ObstaclesSystem.Data;
using UnityEngine;

namespace ObstaclesSystem
{
    [RequireComponent(typeof(MovementComponent))]
    public class BarrierController : MonoBehaviour
    {
        [SerializeField] private ObstacleController _obstaclePrefab = null;
        
        [Header("Spawn Points")]
        [SerializeField] private Transform _obstacleSpawnLeftPoint = null;
        [SerializeField] private Transform _obstacleSpawnMiddlePoint = null;
        [SerializeField] private Transform _obstacleSpawnRightPoint = null;

        [Header("Components")]
        [SerializeField] private MovementComponent _movementComponent = null;

        private void Update()
        {
            _movementComponent.Move(-transform.forward.normalized, 3.0f);
        }

        public void Init(Barrier barrier)
        {
            var leftObstacle = Instantiate(_obstaclePrefab, _obstacleSpawnLeftPoint);
            leftObstacle.Init(barrier.LeftObstacle);
            leftObstacle.HasBeenTriggered += AnyObstacle_HasBeenTriggered;
            
            var middleObstacle = Instantiate(_obstaclePrefab, _obstacleSpawnMiddlePoint);
            middleObstacle.Init(barrier.MiddleObstacle);
            middleObstacle.HasBeenTriggered += AnyObstacle_HasBeenTriggered;
            
            var rightObstacle = Instantiate(_obstaclePrefab, _obstacleSpawnRightPoint);
            rightObstacle.Init(barrier.RightObstacle);
            rightObstacle.HasBeenTriggered += AnyObstacle_HasBeenTriggered;
        }

        private void AnyObstacle_HasBeenTriggered()
        {
            Destroy(gameObject);
        }
    }
}