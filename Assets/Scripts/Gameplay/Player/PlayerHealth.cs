using Gameplay.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Player
{
    public class PlayerHealth : HealthSystem
    {
        private PlayerController _player;
        private SpriteRenderer _spriteRenderer;

        [SerializeField] private Sprite[] DamageStatusFeedback;
        private float LittleDamage = 0.5f;
        private float BigDamage = 0.25f;

        private void Awake()
        {
            TryGetComponent(out _player);
            TryGetComponent(out _spriteRenderer);

            lifeBar = transform.GetChild(5).GetComponentInChildren<Slider>();
        }

        protected override void Start()
        {
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

        public void DamageBoat()
        {
            GetHit(1);
        }
    }
}