using System;
using System.Collections;
using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Bullets
{
    public class Projectiles : MonoBehaviour
    {
        public float Speed { private get; set; }
        public float Damage { private get; set; }
        public float TimeActive { private get; set; }
        public Vector2 Direction { private get; set; }
        
        private Rigidbody2D _rigidbody2D;
        private TrailRenderer _trailRenderer;

        private Coroutine timeToBeDestroyed;
        
        private void Start()
        {
            TryGetComponent(out _rigidbody2D);
            TryGetComponent(out _trailRenderer);
        }

        private void Update()
        {
            _rigidbody2D.velocity = Direction * Speed;
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.GetComponent<HealthSystem>().GetHit(Damage);
        }
        
        public void ResetBullet()
        {
            _trailRenderer?.Clear();

            if (timeToBeDestroyed != null)
            {
                StopCoroutine(timeToBeDestroyed);
            }

            timeToBeDestroyed = StartCoroutine(DeactivateItSelf());
        }
        
        private void DeactivateProjectile()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator DeactivateItSelf()
        {
            yield return new WaitForSeconds(TimeActive);
            
            DeactivateProjectile();
        }
    }
}