using System.Collections.Generic;
using ObstaclesSystem.Data;
using UnityEngine;

namespace ObstaclesSystem
{
    public class BarriersManager : MonoBehaviour
    {
        [SerializeField] private BarrierController _barrierPrefab = null;
        [SerializeField] private Transform _spawnPoint = null;
        [SerializeField] private List<Barrier> _barrierTemplates = null;

        private List<BarrierController> _barriers;
        
        private const float _delayBetweenBarrier = 5.0f;
        private float _timer = 0.0f;
        
        private void Start()
        {
            _barriers = new List<BarrierController>();
            _timer = _delayBetweenBarrier;
        }

        private void Update()
        {
            if (_timer <= 0.0f)
            {
                var barrierInstance = Instantiate(_barrierPrefab, _spawnPoint);
                barrierInstance.Init(_barrierTemplates[Random.Range(0, _barrierTemplates.Count)]);
                _timer = _delayBetweenBarrier;
            }

            _timer -= Time.deltaTime;
        }
    }
}