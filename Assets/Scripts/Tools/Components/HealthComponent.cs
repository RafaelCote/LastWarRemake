using System;
using UnityEngine;

namespace MrHatProduction.Tools.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public event Action Died;
        public event Action HealthChanged;
        
        private int _maxHealth;
        private int _currentHealth = 0;

        public float NormalizedHealth => (float)_currentHealth / _maxHealth;
        public int CurrentHealth => _currentHealth;
        
        public void Init(int maxHealth)
        {
            _maxHealth = maxHealth;
            SetCurrentHealth(_maxHealth);
        }

        public void TakeDamage(int damage)
        {
            SetCurrentHealth(_currentHealth - damage);
            if (_currentHealth <= 0)
                Died?.Invoke();
        }

        public void Heal(int healthAmount)
        {
            SetCurrentHealth(_currentHealth + healthAmount);
        }

        private void SetCurrentHealth(int currentHealth)
        {
            _currentHealth = currentHealth;
            HealthChanged?.Invoke();
        }
    }
}