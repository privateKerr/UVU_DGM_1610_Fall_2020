using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float hInput;
    public float vInput;
    public float xRange = 9;
    public GameManager gameManager;

    public bool hasPowerUp;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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

    private void OnTriggerEnter(Collider collider)
    {
        //Player can collide with health boost
        if (collider.gameObject.CompareTag("Health"))
        {
            Destroy(collider.gameObject);
            gameManager.UpdateHealth(25);
        }
    }

    //Puts powerUp on a countdown
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7); hasPowerUp = false;
    }

}
