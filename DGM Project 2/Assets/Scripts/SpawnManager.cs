using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int animalIndex;
    public float spawnRangeX = 20f;
    public float spawnPosZ = 20f;
    public float startDelay, spawnInterval;

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    void SpawnRandomAnimal()
    {
        // Randomly generate animals at a random location
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Debug.Log(animalIndex);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
