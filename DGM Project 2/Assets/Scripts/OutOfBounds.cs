using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float topBounds = 30f;
    public float lowerBounds = -10f;

    void Awake()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // This will destroy any object entering top bounds
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        // This will destroy any object entering lower bounds
        else if (transform.position.z < lowerBounds)
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            Time.timeScale = 0;
        } 
    }
}
