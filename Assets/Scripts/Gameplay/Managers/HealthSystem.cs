using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Managers
{
    public abstract class HealthSystem : MonoBehaviour
    {
        protected float MaxHealth { get; set; }
        protected float _currentHealth { get; set; }

        protected Slider lifeBar { get; set; }

        protected bool die;

        protected virtual void Start()
        {
            _currentHealth = MaxHealth;

            lifeBar.maxValue = MaxHealth;
            lifeBar.value = MaxHealth;
        }

        public virtual void GetHit(float damage)
        {
            if(die) return;
            
            _currentHealth -= damage;

            if (_currentHealth <= 0f)
            {
                Die();
            }
            else
            {
                lifeBar.value = _currentHealth;
            }
        }

        protected virtual void Die()
        {
            die = true;
            lifeBar.gameObject.transform.parent.gameObject.SetActive(false);
        }
    }
}