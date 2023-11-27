using Gameplay.Managers;
using UnityEngine.AI;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    [Header("Enemies Spawn Information")]
    [SerializeField] private float radiusOfSpawn;
    private float spawnTime;

    [SerializeField] private GameObject[] _enemiesPrefabs;

    private float timmer;
    private bool canGenerate = true;

    private void Start()
    {
        spawnTime = GameController.instance.GetSpawnTime();
    }

    private void FixedUpdate()
    {
        if(!canGenerate) return;
        timmer += Time.deltaTime;
        if (timmer >= spawnTime)
        {
            Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Length)], GetAPositionInMap(),
                Quaternion.identity);
            timmer = 0;
        }
    }

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

    private void StopGeneration()
    {
        canGenerate = false;
    }
        
    private void OnEnable()
    {
        GameController.EndGame += StopGeneration;
    }
    
    private void OnDisable()
    {
        GameController.EndGame -= StopGeneration;
    }
}

