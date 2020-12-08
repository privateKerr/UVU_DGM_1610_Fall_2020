using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 15f;
    private float xRange = 10f;
    private float spawnPosZ = 20f;
    private GameManager gameManager;

    void Start()
    {
        transform.position = SpawnRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }


    //Random spawn position
    private Vector3 SpawnRandomPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 1, spawnPosZ);
        return spawnPos;
    }


}
