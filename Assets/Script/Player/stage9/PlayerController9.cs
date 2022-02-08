using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerController9 : MonoBehaviour
{
    GameObject HP;
    //imageのコンポーネント
    Image gaugeCtrl;

    private float time = 0.0f;

    public GameObject RP;
    public GameObject RP2;
    public GameObject RP3;

    GameObject Player;

    [SerializeField]
    GameObject GoalLine_PL; // 移動予定地のオブジェクト

    public int flg = 1;      //進むか止まるかのフラグ

    Vector3 tmp, tmp2, tmp3;//リスポーンポイントの座標が入る変数
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;
    

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    float speed;

    public bool Turn_L, Turn_R, Turn_S;

    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //カメラのフラグ初期はメインの為false
        Cflg = false;

        Player = GameObject.Find("Boat_Player");

        this.timeToEnableInputs = Time.time + 3.0f;


        rb = GetComponent<Rigidbody>();

        //リスポーン一ポイントのデータを受け取る
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        RP3 = GameObject.Find("RespawnPoint3");
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;
        tmp3 = RP3.transform.position;

        var agentRigidbody = GetComponent<Rigidbody>();

        Turn_L = false;
        Turn_R = false;
        Turn_S = false;

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Gimmick_Conveyer")
        {
            speed = 10.0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Gimmick_Conveyer")
        {
            speed = 8.0f;
        }

        if (collision.gameObject.name == "Gimmick_Move_PC")
        {
            transform.SetParent(null);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var agentRigidbody = GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "Dead")
        {
            Debug.Log("死んだ！！1");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }

        if (collision.gameObject.tag == "Shark")
        {
            Debug.Log("死んだ！！1");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }

        if (collision.gameObject.tag == "Roller")
        {
            Debug.Log("死んだ！！Roller");
            Turn_L = false;
            Turn_S = true;
            Turn_R = false;
            
        }
        if (collision.gameObject.tag == "Yokoari")
        {
            Debug.Log("死んだ！！Yokoari");
            Turn_L = false;
            Turn_S = true;
            Turn_R = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("死んだ！");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }

        if (other.tag == "Goal")
        {
            Debug.Log("ゴーーール");
            Gflg = true;
        }

        if (other.gameObject.tag == "Respawn2")
        {
            Debug.Log("Respawn2にふれた");
            tmp = tmp2;
        }
        if (other.gameObject.tag == "Respawn3")
        {
            Debug.Log("Respawn3にふれた");
            tmp = tmp3;
            //Cflg = true;
        }

        if (other.gameObject.tag == "Turn_L")
        {
            Debug.Log("Turn_Lにふれた");
            Turn_L = true;
        }
        if (other.gameObject.tag == "Turn_S")
        {
            Debug.Log("Turn_Sにふれた");
            Turn_S = true;
        }
        if (other.gameObject.tag == "Turn_R")
        {
            Debug.Log("Turn_Rにふれた");
            Turn_R = true;
        }
        if (other.gameObject.tag == "jump")
        {
            Debug.Log("jumpに触れた");
        }
    }



    void Update()
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                //Cflg = false;
                if (gaugeCtrl.fillAmount > 0.0f)
                {

                    if (Input.GetMouseButton(0))
                    {
                        //マウスが押されているときはゲージを減らし止まる
                        gaugeCtrl.fillAmount -= 0.0013f;
                        flg = 0;
                    }

                    else
                    {
                        //マウスが押されていないときはゲージの回復
                        gaugeCtrl.fillAmount += 0.0005f;
                        flg = 1;
                    }

                }
                else if (gaugeCtrl.fillAmount <= 0.0f)
                {
                    //マウスが押されていないときはゲージの回復
                    //gaugeCtrl.fillAmount += 0.0005f;
                    gaugeCtrl.fillAmount += 0.0025f;
                    flg = 1;
                }
                if (flg == 1)
                {

                    Player.transform.position += -transform.right * speed * Time.deltaTime;

                }
                if (Turn_S == true)
                {
                    transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
                    Turn_S = false;

                }
                if (Turn_L == true)
                {
                    transform.rotation = Quaternion.AngleAxis(-180, new Vector3(0, 1, 0));
                    Turn_L = false;

                }
                if (Turn_R == true)
                {
                    transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 1, 0));
                    Turn_R = false;

                }
            }  
        }
    }
}
