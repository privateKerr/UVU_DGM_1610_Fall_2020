using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float lowerBound = -14f;

    // Update is called once per frame
    void Update()
    {
        //Destroys anything that passes through lower boundary
        if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
        
    }
}
