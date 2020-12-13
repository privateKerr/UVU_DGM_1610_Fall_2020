using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatRoad : MonoBehaviour
{
    public Vector3 startPos;
    private float repeatLength;
    private float speed = 15;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z * 3;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Repeats road for seamless movement in game
    void Update()
    {    
        {
            if (gameManager.isGameActive)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (transform.position.z < startPos.z - repeatLength)
            {
                transform.position = startPos;
            }

        }
    }
}