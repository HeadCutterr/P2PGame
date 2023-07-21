using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class HPScript : MonoBehaviour
{
    public GameObject player;
    PhotonView view;
    public BulletScrupt Bull;
    public Image HealthBar;
    public float MaxHP = 100f;
    public float HP;
    void Start()
    {
        GameObject healthBarObject = GameObject.Find("HPBar");
        HealthBar = healthBarObject.GetComponent<Image>();
        HP = MaxHP;

        view = GetComponent<PhotonView>();
    }

    [PunRPC]
    public void ApplyDamage(int damage)
    {
        


        HP -= damage;

        if (HP <= 0)
        {
            if (view.IsMine)
            {
                HP = 0;
                PhotonNetwork.Destroy(player);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Menu");
            }
        }

    }


    public void Damages(int damage)
    {
        view.RPC("ApplyDamage", RpcTarget.AllBuffered, damage);
    }

    

    void Update()
    {


        if (view.IsMine)
        {
            HealthBar.fillAmount = HP / MaxHP;
        }
    }


}
