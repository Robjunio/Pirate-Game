using System;
using UnityEngine;

namespace Gameplay.Managers
{
    public abstract class HealthSystem : MonoBehaviour
    {
        protected float MaxHealth { get; set; }
        protected float _currentHealth { get; set; }

        protected virtual void Start()
        {
            _currentHealth = MaxHealth;
        }

        public virtual void GetHit(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0f)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            
        }
    }
}