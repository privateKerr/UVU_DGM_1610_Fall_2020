using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25,0,0);

    private float spawnDelay;

    private float repeatDelay;

    // Invokes SpawnObstacles method at start of play
    void Start()
    {
        InvokeRepeating("SpawnObstacles", spawnDelay, repeatDelay);
    }

    // Spawns obstacles at the set spawn position
    void SpawnObstacles()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
