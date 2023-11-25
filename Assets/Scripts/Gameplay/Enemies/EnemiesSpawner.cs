using UnityEngine.AI;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private float radiusOfSpawn;

    private Vector2 GetAPositionInMap()
    {
        var pos = Random.insideUnitCircle * radiusOfSpawn;
        
        if (NavMesh.SamplePosition(pos, out var navMeshHit, 10f, NavMesh.AllAreas))
        {
            Vector2 navMeshPosition = navMeshHit.position;
            return navMeshPosition;
        }
        
        return GetAPositionInMap();
    }
}
