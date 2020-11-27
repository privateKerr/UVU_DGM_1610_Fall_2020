using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject healthPrefab;
    public int obstacleIndex;
    public int enemyCount;
    public int waveNumber = 5;
    private float xRange = 10f;
    private float spawnPosZ = 20f;
    private float spawnDelay = 3f;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomObstacle", spawnDelay);
    }

    void SpawnRandomObstacle()
    {
        // Generate random obstacle 
        spawnInterval = Random.Range(1f, 2f);
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Debug.Log(obstacleIndex);
        Invoke("SpawnRandomObstacle", spawnInterval);

        // Instantiate obstacle at random spawn location
        Instantiate(obstaclePrefabs[obstacleIndex], SpawnRandomPosition(), obstaclePrefabs[obstacleIndex].transform.rotation);
    } 


    //Random spawn position
    private Vector3 SpawnRandomPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 1, spawnPosZ);
        return spawnPos;
    }
}
