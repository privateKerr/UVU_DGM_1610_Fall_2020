using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;

    public GameObject focalPoint;

    public bool hasPowerUp;

    public float speed;

    [SerializeField] float powerUpStr = 15.0f;

    public GameObject powerUpIndicator;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0,-.3f, 0);
    }

    //Gives player powerUp 
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Debug.Log("PowerUp" + hasPowerUp);
            Destroy(collider.gameObject);
            StartCoroutine(PowerUpCountDown());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    //Makes it so powerUp pushes enemy away from player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&& hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Player collided with" + collision.gameObject + "with powerup set to" + hasPowerUp);
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStr, ForceMode.Impulse);
        }
    }

    //Puts power up on a timer
    IEnumerator PowerUpCountDown()
    {
        yield return new WaitForSeconds(7); hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
