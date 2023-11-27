using System;
using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Enemies
{
    public abstract class EnemyBehaviourManager : MonoBehaviour
    {
        [Header("Enemy Attributes")]
        [SerializeField] private float MaxHealth;
        [SerializeField] private float speed;
        [SerializeField] private float attackingSpeed;
        [SerializeField] private float cooldownBetweenAttacks;
        [SerializeField] private float damage;

        [Header("Shooting Hability")] 
        [SerializeField] private GameObject cannonBallPrefab;
        [SerializeField] private float shootSpeed;
        [SerializeField] private float shootDuration;

        private SpriteRenderer _renderer;
        private NavMeshAgent _agent;
        private EnemyHealth _health;

        public EnemyBaseBehaviour AttackBehaviour { get; protected set; }
        public EnemyBaseBehaviour FollowBehaviour { get; protected set; }

        protected virtual void Start()
        {
            TryGetComponent(out _renderer);
            TryGetComponent(out _agent);
        }

        public virtual void ChangeMood(EnemyBaseBehaviour behaviour)
        {
            
        }

        public virtual void InstanceAnShoot(Vector2 dir)
        {
            
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            return _renderer;
        }

        public NavMeshAgent GetNavMeshAgent()
        {
            return _agent;
        }

        public EnemyHealth GetEnemyHealth()
        {
            return _health;
        }
        
        public float GetSpeed()
        {
            return speed;
        }
        
        public float GetAttackingSpeed()
        {
            return attackingSpeed;
        }
        
        public float GetAttackCooldown()
        {
            return cooldownBetweenAttacks;
        }
        
        public float GetDamage()
        {
            return damage;
        }

        public float GetMaxHealth()
        {
            return MaxHealth;
        }

        public GameObject GetBulletPrefab()
        {
            return cannonBallPrefab;
        }

        public float GetBulletSpeed()
        {
            return shootSpeed;
        }
        
        public float GetBulletDuration()
        {
            return shootDuration;
        }
    }
}
