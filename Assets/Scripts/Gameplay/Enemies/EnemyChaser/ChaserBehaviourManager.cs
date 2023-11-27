using System;
using UnityEngine;

namespace Gameplay.Enemies.EnemyChaser
{
    public class ChaserBehaviourManager : EnemyBehaviourManager
    {
        private EnemyBaseBehaviour _currentBehaviour;

        protected override void Start()
        {
            base.Start();

            AttackBehaviour = new ChaserAttackBehaviour();
            FollowBehaviour = new ChaserFollowBehaviour();
            
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
    }
}