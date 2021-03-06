﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    private float hInput;
    private float vInput;
    private float xRange = 9;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.isGameActive)
        {
            // Gives player side to side movement
            hInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * hInput * Time.deltaTime * speed);

            // Gives player forward movement
            vInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * vInput * Time.deltaTime * speed);

            // Constricts player movement on x axis
            if (transform.position.x > xRange)
            {
                transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -xRange)
            {
                transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            }

            // Constricts player movement on z axis
            if (transform.position.z < -12)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -12);
            }
            if (transform.position.z > -4)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -4);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //Takes away health on obstacle collision
        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collider.gameObject);
            gameManager.UpdateLives(-1);
            Debug.Log("Collided with obstacle");
        }

        //Adds health in game manager on health collision
        if (collider.gameObject.CompareTag("Health"))
        {
            Destroy(collider.gameObject);
            gameManager.UpdateLives(+1);
            Debug.Log("Collided with health");
        }
    }
   
}