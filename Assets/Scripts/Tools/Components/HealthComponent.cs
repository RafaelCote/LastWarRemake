using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action Died;
        public event Action<int> HealthChanged;
        
        private int _maxHealth;
        private int _currentHealth = 0;

        public float NormalizedHealth => (float)_currentHealth / _maxHealth;
        
        public void Init(int maxHealth)
        {
            _currentHealth = _maxHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                Died?.Invoke();
            else
                HealthChanged?.Invoke(_currentHealth);
        }
    }
}