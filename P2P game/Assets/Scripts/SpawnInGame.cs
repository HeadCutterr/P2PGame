using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnInGame : MonoBehaviour
{
    public GameObject player;
    public Transform[] Spawns = new Transform[9];
    void Start()
    {
        
        int randomIndex = Random.Range(0, Spawns.Length);
        PhotonNetwork.Instantiate(player.name, Spawns[randomIndex].position, Quaternion.identity);
    }


}
