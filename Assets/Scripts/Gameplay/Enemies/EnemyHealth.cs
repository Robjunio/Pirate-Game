using Gameplay.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Enemies
{
    public class EnemyHealth : HealthSystem
    {
        private EnemyBehaviourManager _enemyController;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite[] DamageStatusFeedback;
        private float LittleDamage = 0.5f;
        private float BigDamage = 0.25f;

        protected override void Start()
        {
            TryGetComponent(out _enemyController);
            TryGetComponent(out _spriteRenderer);
            
            MaxHealth = _enemyController.GetMaxHealth();
            lifeBar = transform.GetChild(0).GetComponentInChildren<Slider>();
            
            base.Start();
        }

        public override void GetHit(float damage)
        {
            base.GetHit(damage);
            
            if (_currentHealth / MaxHealth <= LittleDamage)
            {
                _spriteRenderer.sprite = DamageStatusFeedback[0];
            }
            if (_currentHealth / MaxHealth <= BigDamage)
            {
                _spriteRenderer.sprite = DamageStatusFeedback[1];
            }
        }

        protected override void Die()
        {
            base.Die();
            
            ScoreManager.instance.ScorePoint();
            Destroy(gameObject);
        }
    }
}