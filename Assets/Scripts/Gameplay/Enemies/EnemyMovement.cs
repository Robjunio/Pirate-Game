using UnityEngine;
using UnityEngine.AI;

namespace Gameplay.Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent _agent;
        
        private void Start()
        {
            TryGetComponent(out _agent);
            MarkDestiny();
        }
        
        private void MarkDestiny()
        {
            var pos = Random.insideUnitCircle * 20f;

            if (NavMesh.SamplePosition(pos, out var navMeshHit, 10f, NavMesh.AllAreas))
            {
                Vector2 navMeshPosition = navMeshHit.position;
                _agent.SetDestination(navMeshPosition);
            }
            else
            {
                MarkDestiny();
            }
        }
    }
}