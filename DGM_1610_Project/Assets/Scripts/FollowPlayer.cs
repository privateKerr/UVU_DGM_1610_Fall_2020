using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 7, -10);

    // Update is called once per frame
    void LateUpdate()
    {
        // Makes main camera follow player position
        transform.position = player.transform.position + offset;
    }
}
