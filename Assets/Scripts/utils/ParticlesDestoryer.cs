using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDestoryer : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    void Start()
    {
        Invoke(nameof(DestroyObj), timeToDestroy);
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
