using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    private Vector3 playerVector;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        playerVector = player.position;
        playerVector.z = -10;
        transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);
    }
}
