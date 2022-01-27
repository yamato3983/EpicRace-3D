using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(Animator))]

public class PlayerController7 : MonoBehaviour
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
    public bool Rag = false;

    public GameObject timer;
    public Countdown t1;
    private float timeToEnableInputs;

    float speed;

    Rigidbody[] ragdollRigidbodies;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8.0f;
        HP = GameObject.Find("HP");
        gaugeCtrl = HP.GetComponent<Image>();
        gaugeCtrl.fillAmount = 1.0f;

        //カメラのフラグ初期はメインの為false
        Cflg = false;

        Player = GameObject.Find("unitychan");

        this.timeToEnableInputs = Time.time + 3.0f;

        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        //リスポーン一ポイントのデータを受け取る
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        RP3 = GameObject.Find("RespawnPoint3");
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;
        tmp3 = RP3.transform.position;

        var agentRigidbody = GetComponent<Rigidbody>();
        //RigidodyのKinematicをスタート時はOFFにする
        agentRigidbody.isKinematic = false;

        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        SetRagdoll(false);

    }

    void SetRagdoll(bool isEnabled)
    {
        foreach (Rigidbody rigidbody in ragdollRigidbodies)
        {
            animator.enabled = !isEnabled;
        }
    }
    private IEnumerator Test()
    {
        Rag = true;
        SetRagdoll(true);
        yield return new WaitForSeconds(1.0f);
        SetRagdoll(false);
        animator.enabled = true;
        this.gameObject.SetActive(false);
        Player.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

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
            SetRagdoll(false);
        }

        if (collision.gameObject.tag == "Roller")
        {
            Debug.Log("死んだ！！Roller");
           
            StartCoroutine(Test());
        }
        //if (collision.gameObject.tag == "Yokoari")
        //{
        //    Debug.Log("死んだ！！Yokoari");
            
        //    StartCoroutine(Test());
        //}

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

            //NavmeshとRigidodyのKinematicがON
            agentRigidbody.isKinematic = true;
            //agent.enabled = true;
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
        }
        if (other.gameObject.tag == "Yokoari")
        {
            Debug.Log("死んだ！！Yokoari");

            StartCoroutine(Test());
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
                    if (Rag == true)
                    {
                        flg = 0;
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
            //if (Cflg == true)
            //{
            //    // RunからWaitに遷移する
            //    this.animator.SetBool(key_isRun, false);
            //}
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
