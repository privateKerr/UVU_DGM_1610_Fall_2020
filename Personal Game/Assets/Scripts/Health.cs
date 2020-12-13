using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    private float xRange = 10f;
    private float spawnPosZ = 20f;
    private GameManager gameManager;

    void Start()
    {
        transform.position = SpawnRandomPosition();
    }

    // Destroys health when passing out of bounds
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < -14)
        {
            Destroy(gameObject);
        }
    }


    //Random spawn position
    private Vector3 SpawnRandomPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 1, spawnPosZ);
        return spawnPos;
    }

}