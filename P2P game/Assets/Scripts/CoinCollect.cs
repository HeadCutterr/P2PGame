using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CoinCollect : MonoBehaviour
{
    private CoinScript coinScript;
    private GameObject coinObject;
    // Start is called before the first frame update
    void Start()
    {
        coinScript = FindObjectOfType<CoinScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinScript(CoinScript script, GameObject coin)
    {
        coinScript = script;
        coinObject = coin;
    }



}
