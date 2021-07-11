using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    GameObject HP;
    //imageのコンポーネント
    Image gaugeCtrl;

    // Animator コンポーネント
    private Animator animator;

    // Animatorの設定したフラグの名前
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    //リスポーンポイントを格納する変数
    public GameObject RP;
    public GameObject RP2;

    //プレイヤーを格納する変数
    GameObject Player;

    GameObject PB;//箱ギミックを格納する変数
    PivotAngle_Box PB_Script;//PivotAngle_Boxが入る変数

    [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト

    public NavMeshAgent agent;

    int flg = 1;      //進むか止まるかのフラグ

    Vector3 tmp, tmp2;//リスポーンポイントの座標が入る変数
    public Rigidbody rb;

    public bool Gflg = false;
    public bool Dead = false;
    public bool Cflg = false;

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = 5.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //カメラのフラグ初期はメインの為false
        Cflg = false;

        Player = GameObject.Find("unitychan");

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
        //tmp2 = RP2.transform.position;

        PB = GameObject.Find("PivotBox");
        PB_Script = PB.GetComponent<PivotAngle_Box>();

        var agentRigidbody = agent.GetComponent<Rigidbody>();
        //RigidodyのKinematicをスタート時はONにする
        agentRigidbody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        bool boxflg = PB_Script.gimmickFlag_Box;

        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.tag == "Gimmick_Box" && boxflg == false)
        {
            Debug.Log("落ちる！！");
            //Cflg = false;

            //NavmeshもRigidodyのKinematicもOFF
            agent.enabled = false;
            agentRigidbody.isKinematic = false;
            flg = 0;
        }
        if (other.tag == "Gimmick_Conveyer")
        {
            agent.speed = 2.0f;
        }
        else
        {
            agent.speed = 5.0f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            Debug.Log("死んだ！！");
            this.gameObject.SetActive(false);
            agent.Warp(new Vector3(tmp.x, tmp.y, tmp.z));
            Dead = true;
            flg = 0;

            //NavmeshとRigidodyのKinematicがON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }

        if (other.gameObject.tag == "Dead_02")
        {
            Debug.Log("死んだ！！(回転");
            this.gameObject.SetActive(false);
            agent.Warp(new Vector3(tmp2.x, tmp2.y, tmp2.z));
            Dead = true;
            flg = 0;


            //NavmeshとRigidodyのKinematicがON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }

        if (other.tag == "Goal")
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            Debug.Log("ゴーーール");
            Gflg = true;
        }

        if (other.gameObject.tag == "Respawn2")
        {
            Debug.Log("Respawn2にふれた");
            Cflg = true;
        }

        if (other.gameObject.tag == "EndGimmick")
        {
            Debug.Log("EndGimmickにふれた");
            Cflg = false;
        }
    }

    void Update()
    {

        if (Time.time >= this.timeToEnableInputs)
        {
            if (Gflg == false && Dead == false)
            {
                if (gaugeCtrl.fillAmount > 0.0f)
                {
                    if (Input.GetMouseButton(0))
                    {
                        gaugeCtrl.fillAmount -= 0.0013f;
                        flg = 0;
                    }

                    else
                    {
                        // RunからWaitに遷移する
                        //this.animator.SetBool(key_isRun, false);
                        flg = 1;
                    }
                }
                else if (gaugeCtrl.fillAmount == 0.0f)
                {
                    flg = 1;
                }
                if (flg == 1)
                {
                    // WaitからRunに遷移する
                    this.animator.SetBool(key_isRun, true);
                    agent.GetComponent<NavMeshAgent>().isStopped = false;
                    agent.SetDestination(GoalLine_PL.transform.position);
                }
                else if (flg == 0)
                {
                    // RunからWaitに遷移する
                    this.animator.SetBool(key_isRun, false);
                    agent.velocity = Vector3.zero;
                    agent.GetComponent<NavMeshAgent>().isStopped = true;
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
