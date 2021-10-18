using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move3 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;


    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 4.0f;
    //　速度
    private Vector3 velocity;

    //　ジャンプ力
    [SerializeField]
    private float jumpPower = 2.0f;

    //　移動方向
    private Vector3 direction;

    [SerializeField]
    public Rigidbody rb;


    //ジャンプ台用のスクリプト
    GameObject JumpPad;
    public JumpPad jump_script;

    public bool j_flg;

    public float upForce = 50f; //上方向にかける力


    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //リスポーン
    public GameObject rp1;
    public GameObject rp2;
    public GameObject rp3;


    Vector3 pos1, pos2, pos3;

    public bool dead;

    //NPCがゴールをしたかどうか
    public bool goal;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
        GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = new Vector3(tmp.x, tmp.y, tmp.z);
        velocity = Vector3.zero;

        //リスポーン
        rp1 = GameObject.Find("RespawnCPU");
        rp2 = GameObject.Find("RespawnCPU2");
        rp3 = GameObject.Find("RespawnCPU3");
       
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;
        pos3 = rp3.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            direction = (destination - transform.position).normalized;
            StartCoroutine("Dush");
            if (script_t1.startflg == true)
            {
                velocity = direction * walkSpeed;
            }
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

        j_flg = false;
        dead = false;
    }

    private IEnumerator Dush()
    {
        //カウントダウン中はストップしてる
        if (script_t1.startflg == false)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        //とりあえず4秒にしてるけど変更するかも
        yield return new WaitForSeconds(3.0f);

        //カウントダウンが0のときに走り出す
        if (script_t1.startflg == true)
        {
            animator.SetFloat("Speed", 4.0f);
        }
    }

    //タグの判定(Stay)
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "jump")
        {
            if (jump_script.Gimmick_Jump == true)
            {
                velocity.y += jumpPower;
            }
        }

        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Dead")
        {
            dead = true;
            j_flg = false;
            Enemy.SetActive(false);
            //1秒後にCallRespawn2関数を実行する
            Invoke("CallRespawn2", 2f);
        }

        if(other.tag == "Dead_02")
        {
            dead = true;
            j_flg = false;
            Enemy.SetActive(false);
            Invoke("CallRespawn3", 2f);
        }


        if (other.tag == "Hammer")
        {
            dead = true;
            Enemy.SetActive(false);
            //1秒後にCallRespawn1関数を実行する
            Invoke("CallRespawn1", 2f);

        }


        if (other.tag == "Goal")
        {
            goal = true;
            walkSpeed = 0f;
        }
    }

    //何秒後かに呼び出すための処理
    void Call()
    {
        walkSpeed = 5.0f;
    }

    //復活のためのクールタイム用
    void CallRespawn1()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }

    void CallRespawn2()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos2.x, pos2.y, pos2.z);
    }

    void CallRespawn3()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos3.x, pos3.y, pos3.z);
    }

}
