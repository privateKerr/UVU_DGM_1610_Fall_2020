using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    public Vector3 startPos;
    private float repeatLength;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z * 3;
    }

    // Update is called once per frame
    void Update()
    {    
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (transform.position.z < startPos.z - repeatLength)
            {
                transform.position = startPos;
            }

        }
    }
}