using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public int obstacleIndex;
    public float xRange = 10f;
    public float spawnPosZ = 20f;
    public float spawnDelay = 3f;
    public float spawnInterval;




    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomObstacle", spawnDelay);
    }

    void SpawnRandomObstacle()
    {
        // Generate random obstacle index and random spawn location
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, spawnPosZ);
        spawnInterval = Random.Range(1f, 3f);
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Debug.Log(obstacleIndex);
        Invoke("SpawnRandomObstacle", spawnInterval);

        // Instantiate obstacle at random spawn location
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);

    }



}
