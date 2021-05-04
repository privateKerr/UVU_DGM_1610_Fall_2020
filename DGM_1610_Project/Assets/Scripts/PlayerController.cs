using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] static float horsePower;
    [SerializeField] float turnSpeed = 100f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Will move the vehicle forward based on vertical input

        //transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);

        // Rotates vehicle based on horizontal input

        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

    }
}
