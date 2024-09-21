using MrHatProduction.Tools.Components;
using UnityEngine;

namespace UI
{
    public class UIUnitHealth : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent = null;
        [SerializeField] private SlicedFilledImage _fill = null;

        private void Start()
        {
            _healthComponent.HealthChanged += HealthComponent_HealthChanged;
        }

        private void OnDestroy()
        {
            _healthComponent.HealthChanged -= HealthComponent_HealthChanged;
        }

        private void HealthComponent_HealthChanged()
        {
            _fill.fillAmount = _healthComponent.NormalizedHealth;
        }
    }
}
