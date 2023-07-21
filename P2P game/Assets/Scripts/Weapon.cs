using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Weapon : MonoBehaviourPun
{
    [SerializeField]
    public Transform firePoint;
    public GameObject Bullet;
    public FirePointConnect FPC;
    public GameObject playerPrefab;
    public GameObject Player;




    public void Start()
    {
        firePoint = Player.transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not found!");
        }
    }
    [PunRPC]
    void Update()
    {
        
    }

    [PunRPC]
    public void AllShoot()
    {
        this.GetComponent<PhotonView>().RPC("Shoot", RpcTarget.All);
    }


    [PunRPC]
    public void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }
    public void PressFire()
    {
        Shoot();
    }
}
