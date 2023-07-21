using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public PlayerScripts PS;
    public GameObject UWin;
    public HPScript HPS;
    PhotonView view;
    public bool GameStart = false;
    [PunRPC]
    public void SetGameStart(bool value)
    {
        GameStart = value;
    }
    public GameObject StartButton;
    public int maxPlayers = 6;
    public Sprite[] SkinsImage = new Sprite[5];
    public Text Name;
    public Text NameObj;
    public short SkinShow;
    public Image UrSkin;

    public void Start()
    {
        NameObj = GameObject.FindGameObjectWithTag("PlayerName").GetComponent<Text>();
        UWin.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        view = GetComponent<PhotonView>();

    }

    void Update()
    {
        SkinShow = PS.Skin;
        if (view.IsMine)
        {
            StartButton.gameObject.SetActive(true);
            if (GameStart == true)
            {
                StartButton.gameObject.SetActive(false);
            }

            
            if (GameStart == true && PhotonNetwork.CurrentRoom.PlayerCount <= 1)
            {
                
                UWin.gameObject.SetActive(true);
                Name.text = view.Owner.NickName;
                NameObj.gameObject.SetActive(false);
                if(SkinShow == 0)
                {
                    UrSkin.sprite = SkinsImage[0];
                }
                if (SkinShow == 1)
                {
                    UrSkin.sprite = SkinsImage[1];
                }
                if (SkinShow == 2)
                {
                    UrSkin.sprite = SkinsImage[2];
                }
                if (SkinShow == 3)
                {
                    UrSkin.sprite = SkinsImage[3];
                }
                if (SkinShow == 4)
                {
                    UrSkin.sprite = SkinsImage[4];
                }


            }
        }
    }
    public void Lobby()
    {
        PhotonNetwork.Destroy(Player);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        GameStart = true;
        view.RPC("SetGameStart", RpcTarget.All, GameStart);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(GameStart);
        }
        else
        {
            GameStart = (bool)stream.ReceiveNext();
        }
    }

}
