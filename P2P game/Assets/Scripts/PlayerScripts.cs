using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PlayerScripts : MonoBehaviourPunCallbacks
{
    public GameManager GM;
    public LobbyScript LBS;
    public float speed;
    PhotonView view;
    Animator anim;
    Animator anim1;
    Animator anim2;
    Animator anim3;
    Animator anim4;
    Rigidbody2D rb;
    private float X, Y;
    private Joystick joystick;
    private bool IsR;
    public Text Nickfield;
    public short Skin = 0;
    public string CurrentAnim;
    public Text CoinCounter;
    public short NumberCoins;

    void Start()
    {
        GameObject GameManager = GameObject.FindGameObjectWithTag("GameManager");
        GM = GameManager.GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();

        Nickfield.text = view.Owner.NickName;

        view.RPC("SyncIsR", RpcTarget.Others, IsR);
    }
    [PunRPC]
    public void ChangeAnim(string animation)
    {
        if (CurrentAnim == animation) return;
        anim.Play(animation);
        CurrentAnim = animation;
    }
    void Update()
    {
        if (view.IsMine)
        {
            GameObject[] CCount = GameObject.FindGameObjectsWithTag("CoinCounter");
            foreach (GameObject obj in CCount)
            {
                Text coinCounterText = obj.GetComponent<Text>();
                coinCounterText.text = NumberCoins.ToString();
            }
        }
        X = joystick.Horizontal * speed;
        Y = joystick.Vertical * speed;

        if (view.IsMine)
        {
            rb.velocity = new Vector2(X, Y);
        }

        
        if (view.IsMine)
        {


            if ((X == 0 || Y == 0) && Skin == 0 )
            {
                ChangeAnim("Man1_IDLE");
                view.RPC("ChangeAnim", RpcTarget.All, "Man1_IDLE");

            }
            else if ((X != 0 || Y != 0) && Skin == 0)
            {
                ChangeAnim("Man1_Run");
                view.RPC("ChangeAnim", RpcTarget.All, "Man1_Run");
            }

            if ((X == 0 || Y == 0) && Skin == 1)
            {
                ChangeAnim("Man2_IDLE");
                view.RPC("ChangeAnim", RpcTarget.All, "Man2_IDLE");
            }
            else if ((X != 0 || Y != 0) && Skin == 1)
            {
                ChangeAnim("Man2_Run1");
                view.RPC("ChangeAnim", RpcTarget.All, "Man2_Run1");
            }

            if ((X == 0 || Y == 0) && Skin == 2)
            {
                ChangeAnim("Man3_IDLE");
                view.RPC("ChangeAnim", RpcTarget.All, "Man3_IDLE");
            }
            else if ((X != 0 || Y != 0) && Skin == 2)
            {
                ChangeAnim("Man3_Run");
                view.RPC("ChangeAnim", RpcTarget.All, "Man3_Run");
            }

            if ((X == 0 || Y == 0) && Skin == 3)
            {
                ChangeAnim("Man4_IDLE");
                view.RPC("ChangeAnim", RpcTarget.All, "Man4_IDLE");
            }
            else if ((X != 0 || Y != 0) && Skin == 3)
            {
                ChangeAnim("Man4_Run");
                view.RPC("ChangeAnim", RpcTarget.All, "Man4_Run");
            }


            if ((X == 0 || Y == 0) && Skin == 4)
            {
                ChangeAnim("Man5_IDLE");
                view.RPC("ChangeAnim", RpcTarget.All, "Man5_IDLE");
            }
            else if ((X != 0 || Y != 0) && Skin == 4)
            {
                ChangeAnim("Man5_Run");
                view.RPC("ChangeAnim", RpcTarget.All, "Man5_Run");
            }


            if (X < 0 && !IsR)
            {
                FlipPlayer();
            }
            else if (X > 0 && IsR)
            {
                FlipPlayer();
            }
        }


    }
    [PunRPC]
    public void FlipPlayer()
    {
        IsR = !IsR;
        transform.Rotate(0f, 180f, 0f);

        Nickfield.transform.Rotate(0f, 180f, 0f);
        view.RPC("FlipPlayer", RpcTarget.Others);
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin") && GM.GameStart == true)
        {
            Destroy(other.gameObject);
            NumberCoins++;
        }
    }

}
