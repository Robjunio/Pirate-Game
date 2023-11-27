using Gameplay.Managers;
using UnityEngine;

namespace Gameplay.Enemies.EnemyChaser
{
    public class ChaserFollowBehaviour : EnemyBaseBehaviour
    {
        private Transform target;
        private float _baseAceleration = 4f;
        private float _stopDistance = 5f;
        
        public override void EnterState(EnemyBehaviourManager enemy)
        {
            target = GameController.instance.GetPlayerTransform();

            enemy.GetNavMeshAgent().speed = enemy.GetSpeed();
            enemy.GetNavMeshAgent().acceleration = _baseAceleration;
            enemy.GetNavMeshAgent().stoppingDistance = _stopDistance;
        }

        public override void UpdateState(EnemyBehaviourManager enemy)
        {
            Rotate(enemy);
            
            if (enemy.GetNavMeshAgent().remainingDistance <= 5f)
            {
                enemy.ChangeMood(enemy.AttackBehaviour);
            }
            enemy.GetNavMeshAgent().SetDestination(target.position);
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
    }
}