using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class FirePointConnect : MonoBehaviourPun
{
    public Weapon Wep;
    public Transform firePoint;
    public GameObject Player;

    public void Start()
    {
        firePoint = Player.transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not found!");
        }

    }
}
