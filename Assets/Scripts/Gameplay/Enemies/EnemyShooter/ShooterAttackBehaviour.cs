using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Enemies.EnemyShooter
{
    public class ShooterAttackBehaviour : EnemyBaseBehaviour
    {
        private Transform target;
        private bool _canShoot = true;
        private float timmer;
        
        public override void EnterState(EnemyBehaviourManager enemy)
        {
            target = GameController.instance.GetPlayerTransform();
        }

        public override void UpdateState(EnemyBehaviourManager enemy)
        {
            Rotate(enemy);

            if (Vector2.Distance(target.position, enemy.transform.position) > 10f)
            {
                enemy.ChangeMood(enemy.FollowBehaviour);
            }
            
            if (_canShoot)
            {
                Shoot(enemy);
            }
            else
            {
                timmer += Time.deltaTime;
                if (timmer >= enemy.GetAttackCooldown())
                {
                    timmer = 0;
                    _canShoot = true;
                }
            }
        }

        public override void OnCollisionEnter(EnemyBehaviourManager enemy, Collision2D col)
        {
            throw new System.NotImplementedException();
        }
        
        private void Rotate(EnemyBehaviourManager enemy)
        {
            Vector3 direction = target.position - enemy.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        
            // Rotate in Z axis;
            Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, angleAxis, Time.deltaTime * 50);
        }

        private void Shoot(EnemyBehaviourManager enemy)
        {
            Vector2 dir = (target.position - enemy.transform.position).normalized;
            
            enemy.InstanceAnShoot(dir);
            _canShoot = false;
        }
    }
}