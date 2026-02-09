using Miscellaneous;
using UnityEngine;

namespace Miscellaneous
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        private float _currentHealth;

        void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth < 0) _currentHealth = 0;
            EventBus.RaiseHealthChanged(_currentHealth);
        }
    }
}
