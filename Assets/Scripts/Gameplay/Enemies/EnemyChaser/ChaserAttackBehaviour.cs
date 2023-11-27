using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Enemies.EnemyChaser
{
    public class ChaserAttackBehaviour : EnemyBaseBehaviour
    {
        private Transform target;
        private float _baseAceleration = 8f;
        private float _stopDistance = 0f;

        private float stunTime;
        private float timmer;
        private bool _canMove = true;
        
        public override void EnterState(EnemyBehaviourManager enemy)
        {
            target = GameController.instance.GetPlayerTransform();

            enemy.GetNavMeshAgent().speed = enemy.GetAttackingSpeed();
            enemy.GetNavMeshAgent().acceleration = _baseAceleration;
            enemy.GetNavMeshAgent().stoppingDistance = _stopDistance;

            stunTime = enemy.GetAttackCooldown();
        }

        public override void UpdateState(EnemyBehaviourManager enemy)
        {
            Rotate(enemy);
            
            if (_canMove)
            {
                enemy.GetNavMeshAgent().SetDestination(target.position);
            }
            else
            {
                timmer += Time.deltaTime;
                if (timmer >= stunTime)
                {
                    timmer = 0;
                    _canMove = true;
                    
                    enemy.ChangeMood(enemy.FollowBehaviour);
                }
            }
        }

        public override void OnCollisionEnter(EnemyBehaviourManager enemy, Collision2D col)
        {
            if (col.gameObject.layer == 8 && _canMove)
            {
                col.gameObject.GetComponent<HealthSystem>().GetHit(enemy.GetDamage());
                _canMove = false;
            }
        }

        private void Rotate(EnemyBehaviourManager enemy)
        {
            Vector3 direction = target.position - enemy.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        
            // Rotate in Z axis;
            Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, angleAxis, Time.deltaTime * 50);
        }
    }
}