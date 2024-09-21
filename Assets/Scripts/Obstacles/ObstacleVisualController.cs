using MrHatProduction.Tools.Components;
using UnityEngine;

namespace ObstacleSystem
{
    public class ObstacleVisualController : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer = null;
        [SerializeField] private HealthComponent _healthComponent = null;

        [SerializeField] private Material _positiveMaterial = null;
        [SerializeField] private Material _negativeMaterial = null;
        
        void Start()
        {
            if (_healthComponent.CurrentHealth >= 0)
                _renderer.material = _positiveMaterial;
            else
                _renderer.material = _negativeMaterial;
            
            _healthComponent.HealthChanged += HealthComponent_HealthChanged;
        }

        private void HealthComponent_HealthChanged()
        { 
            if (_healthComponent.CurrentHealth >= 0)
                _renderer.material = _positiveMaterial;
            else
                _renderer.material = _negativeMaterial;
        }
    }
}
