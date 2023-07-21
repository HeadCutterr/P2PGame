using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMan : MonoBehaviour
{
    public GameManager GM;
    public Weapon Wep;
    public Transform firePoint;

    public void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Wep = playerObject.GetComponent<Weapon>();
        firePoint = Wep.Player.transform.Find("FirePoint");
    }

    public void ToggleShoot()
    {
        if (GM.GameStart == true)
        {
            Wep.AllShoot();
        }
    }
}
