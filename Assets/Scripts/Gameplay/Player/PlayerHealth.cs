using Gameplay.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerHealth : HealthSystem
    {
        private PlayerController _player;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite[] DamageStatusFeedback;
        private float LittleDamage = 0.5f;
        private float BigDamage = 0.2f;

        protected override void Start()
        {
            TryGetComponent(out _player);
            TryGetComponent(out _spriteRenderer);

            MaxHealth = _player.GetMaxHealth();

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
        }

        public void DamageBoat()
        {
            GetHit(1);
        }
    }
}