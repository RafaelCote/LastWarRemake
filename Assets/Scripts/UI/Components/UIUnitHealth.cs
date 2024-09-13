using MrHatProduction.Tools.Components;
using UnityEngine;

namespace UI
{
    public class UIUnitHealth : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent = null;
        [SerializeField] private SlicedFilledImage _fill = null;

        public void Start()
        {
            _healthComponent.HealthChanged += HealthComponent_HealthChanged;
        }

        public void OnDestroy()
        {
            _healthComponent.HealthChanged -= HealthComponent_HealthChanged;
        }

        private void HealthComponent_HealthChanged(int _)
        {
            _fill.fillAmount = _healthComponent.NormalizedHealth;
        }
    }
}
