using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float spawnDelay = 1;
    private float repeatDelay = 4;
    private PlayerController playerControllerScript;

    // Invokes SpawnObstacles method at start of play
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", spawnDelay, repeatDelay);
    }

    // Spawns obstacles at the set spawn position
    void SpawnObstacles()
    {
        //Obstacles will continue to spawn unless gameOver bool is true
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
