using MrHatProduction.Tools.Components;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UIObstacleHealth : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent = null;
        [SerializeField] private TextMeshProUGUI _label = null;
        
        private void Start()
        {
            _healthComponent.HealthChanged += HealthComponent_HealthChanged;
            _label.text = _healthComponent.CurrentHealth.ToString();
        }
        
        private void OnDestroy()
        {
            _healthComponent.HealthChanged += HealthComponent_HealthChanged;
        }

        private void HealthComponent_HealthChanged()
        {
            _label.text = _healthComponent.CurrentHealth.ToString();
        }
    }
}
