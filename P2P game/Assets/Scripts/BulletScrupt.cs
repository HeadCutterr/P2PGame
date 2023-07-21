using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrupt : MonoBehaviour
{
    public CameraScript cams;
    public HPScript HPS;
    public float Speed = 22f;
    public Rigidbody2D rb;
    public GameObject bullet;
    public short Damage;
    void Start()
    {
        rb.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<HPScript>())
        {
            hitInfo.GetComponent<HPScript>().Damages(Damage);
        }
        Destroy(bullet);
    }
}
