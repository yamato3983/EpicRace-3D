using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class YokoariController3 : MonoBehaviour
{
    GameObject HP;
    //imageのコンポーネント
    Image gaugeCtrl;

    // Animator コンポーネント
    private Animator animator;

    // Animatorの設定したフラグの名前
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    public GameObject RP;
    public GameObject RP2;

    GameObject Player;

    [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト
    
    int flg = 1;      //進むか止まるかのフラグ

    Vector3 tmp, tmp2;//リスポーンポイントの座標が入る変数
    Vector3 jp;
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;


    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    float speed;

    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        speed = 7.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //カメラのフラグ初期はメインの為false
        Cflg = true;

        Player = GameObject.Find("yokoaridance");

        //timer = GameObject.Find("Timer");
        //t1 = timer.GetComponent<Countdown>();
        this.timeToEnableInputs = Time.time + 3.0f;


        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        //リスポーン一ポイントのデータを受け取る
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;

        var agentRigidbody = GetComponent<Rigidbody>();
        //RigidodyのKinematicをスタート時はOFFにする
        agentRigidbody.isKinematic = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (collision.gameObject.tag == "Dead")
        {
            Debug.Log("死んだ！！");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp2.x, tmp2.y, tmp2.z);
            Dead = true;
            flg = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Hammer")
        {
            Debug.Log("死んだ！！");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }
        if (other.tag == "Goal")
        {
            //NavMeshAgent agent = GetComponent<NavMeshAgent>();
            //agent.isStopped = true;
            Debug.Log("ゴーーール");
            Gflg = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        var agentRigidbody = GetComponent<Rigidbody>();
        if (other.tag == "Hammer")
        {
            Debug.Log("死んだ！！");
            this.gameObject.SetActive(false);
            Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
            Dead = true;
            flg = 0;
        }

    }




    void Update()
    {
        var agentRigidbody = GetComponent<Rigidbody>();

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                Cflg = false;
                if (gaugeCtrl.fillAmount > 0.0f)
                {

                    if (Input.GetMouseButton(0))
                    {
                        //マウスが押されているときはゲージを減らし止まる
                        gaugeCtrl.fillAmount -= 0.0026f;
                        //gaugeCtrl.fillAmount -= 0.0065f;
                        flg = 0;
                    }

                    else
                    {
                        //マウスが押されていないときはゲージの回復
                        gaugeCtrl.fillAmount += 0.0010f;
                        //gaugeCtrl.fillAmount += 0.0025f;
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount <= 0.0f)
                {
                    //マウスが押されていないときはゲージの回復
                    gaugeCtrl.fillAmount += 0.0010f;
                    //gaugeCtrl.fillAmount += 0.0025f;
                    flg = 1;
                }
                if (flg == 1)
                {
                    // WaitからRunに遷移する
                    this.animator.SetBool(key_isRun, true);
                    Player.transform.position += transform.forward * speed * Time.deltaTime;

                }
                else if (flg == 0)
                {
                    // RunからWaitに遷移する
                    this.animator.SetBool(key_isRun, false);

                }
            }
            if (Dead == true)
            {
                // RunからWaitに遷移する
                this.animator.SetBool(key_isRun, false);
            }
            if (Gflg == true)
            {
                // RunからWaitに遷移する
                this.animator.SetBool(key_isRun, false);

            }
        }
    }
}
