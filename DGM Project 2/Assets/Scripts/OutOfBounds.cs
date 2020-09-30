using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float topBounds = 30f;
    public float lowerBounds = -10f;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        } 
    }
}
