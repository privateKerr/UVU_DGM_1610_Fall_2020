using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float hInput;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
