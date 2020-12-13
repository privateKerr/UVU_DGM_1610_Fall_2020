using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 15f;
    private float xRange = 10f;
    private float spawnPosZ = 20f;
    private GameManager gameManager;

    void Start()
    {
        transform.position = SpawnRandomPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Updates score when obstacle goes out of bounds
    void FixedUpdate()
    {  
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z < -14 && gameManager.isGameActive)
            {
                gameManager.UpdateScore(25);
                Destroy(gameObject);
            }  
    }


    //Random spawn position
    private Vector3 SpawnRandomPosition()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0, spawnPosZ);
        return spawnPos;
    }

}
