using UnityEngine;

namespace Gameplay.Enemies
{
    public abstract class EnemyBaseBehaviour
    {
        public abstract void EnterState(EnemyBehaviourManager enemy);

        public abstract void UpdateState(EnemyBehaviourManager enemy);

        public abstract void OnCollisionEnter(EnemyBehaviourManager enemy, Collision2D col);
        
    }
}
