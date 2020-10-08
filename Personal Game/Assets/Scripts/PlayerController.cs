using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float hInput;
    public float vInput;
    public float xRange = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gives player side to side movement
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);
        // Gives player forward movement
        vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * vInput * Time.deltaTime * speed);

        // Constricts player movement on x axis
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        // Constricts player movement on z axis
        if(transform.position.z < -12)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -12);
        }
        if (transform.position.z > -4)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -4);
        }

    }
}
