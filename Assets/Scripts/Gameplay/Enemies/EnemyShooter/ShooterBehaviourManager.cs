using Gameplay.Bullets;
using UnityEngine;

namespace Gameplay.Enemies.EnemyShooter
{
    public class ShooterBehaviourManager : EnemyBehaviourManager
    {
        private EnemyBaseBehaviour _currentBehaviour;

        protected override void Start()
        {
            base.Start();

            AttackBehaviour = new ShooterAttackBehaviour();
            FollowBehaviour = new ShooterFollowBehaviour();
            
            _currentBehaviour = FollowBehaviour;
            _currentBehaviour.EnterState(this);
        }

        private void FixedUpdate()
        {
            _currentBehaviour.UpdateState(this);
        }

        public override void ChangeMood(EnemyBaseBehaviour behaviour)
        {
            _currentBehaviour = behaviour;
            _currentBehaviour.EnterState(this);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {

            
            _currentBehaviour.OnCollisionEnter(this, col);
        }
        
        public override void InstanceAnShoot(Vector2 dir)
        {
            var bullet = Instantiate(GetBulletPrefab(), transform.position, 
                Quaternion.identity).GetComponent<Projectiles>();
            bullet.Damage = GetDamage();
            bullet.Speed = GetBulletSpeed();
            bullet.Direction = dir;
            bullet.TimeActive = GetBulletDuration();
        }
    }
}