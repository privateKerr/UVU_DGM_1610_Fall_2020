using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    //Destroys obstacles 
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
