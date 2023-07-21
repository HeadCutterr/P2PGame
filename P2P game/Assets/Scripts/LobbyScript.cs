using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviourPunCallbacks
{
    public PlayerScripts Ps;
    public InputField CreateField;
    public InputField JoinField;
    public InputField NickField;
    public short SkinIndex;
    public Sprite[] SkinObj = new Sprite[5];
    public Image SkinSelect;

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        NickField.text = PlayerPrefs.GetString("Name");
        PhotonNetwork.NickName = NickField.text;
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6;
        PhotonNetwork.CreateRoom(CreateField.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(JoinField.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("Name", NickField.text);
        PhotonNetwork.NickName = NickField.text;
    }


    public void Update()
    {
        Ps.Skin = SkinIndex;
    }
    public void NexSkin()
    {
        SkinIndex++;
        if(SkinIndex >= 5)
        {
            SkinIndex = 0;
        }
        if(SkinIndex == 0)
        {
            SkinSelect.sprite = SkinObj[0];
        }
        else if (SkinIndex == 1)
        {
            SkinSelect.sprite = SkinObj[1];
        }
        else if (SkinIndex == 2)
        {
            SkinSelect.sprite = SkinObj[2];
        }
        else if (SkinIndex == 3)
        {
            SkinSelect.sprite = SkinObj[3];
        }
        else if (SkinIndex == 4)
        {
            SkinSelect.sprite = SkinObj[4];
        }

    }

    public void PrevSkin()
    {
        SkinIndex--;
        if(SkinIndex <= -1)
        {
            SkinIndex = 4;
        }
        if (SkinIndex == 0)
        {
            SkinSelect.sprite = SkinObj[0];
        }
        else if (SkinIndex == 1)
        {
            SkinSelect.sprite = SkinObj[1];
        }
        else if (SkinIndex == 2)
        {
            SkinSelect.sprite = SkinObj[2];
        }
        else if (SkinIndex == 3)
        {
            SkinSelect.sprite = SkinObj[3];
        }
        else if (SkinIndex == 4)
        {
            SkinSelect.sprite = SkinObj[4];
        }

    }
}
