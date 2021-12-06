using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move06 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 1.0f;

    //　ジャンプ力
    [SerializeField]
    private float jumpPower = 15.0f;

    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;

    //ジャンプ台用のスクリプト
    GameObject JumpPad;
    public JumpPad jump_script;

    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    private bool conflag;

    //リスポーン
    //public GameObject rp1;
    //public GameObject rp2;

    Vector3 pos1, pos2;


    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;

    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;

    private bool move;
    private bool judge;


    private bool isRespon = false;

    private bool jump;
    public bool dead;

    //NPCがゴールをしたかどうか
    public bool goal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
        GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        enemyController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        destination = new Vector3(tmp.x, tmp.y, tmp.z);
        velocity = Vector3.zero;

        //リスポーン
        /* rp1 = GameObject.Find("RespawnCPU");
         rp2 = GameObject.Find("RespawnCPU2");
         pos1 = rp1.transform.position;
         pos2 = rp2.transform.position;*/

        judge = false;
        move = false;
        dead = false;
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

        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;

        //コンベアー用
        if (conflag == true)
        {
            walkSpeed = 10.0f;
        }
        if (conflag == false)
        {
            //walkSpeed = 7.0f;

        }

        if (move == true)
        {
            this.gameObject.transform.Translate(0, 0, 0.035f);
        }

        if (judge == true && move == false)
        {
            walkSpeed = 0.0f;
        }

        

        // float current_speed = animator.GetFloat("Speed");

        // モーション切り替えを10秒で完結させる
        //animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);

    }

    private IEnumerator Dush()
    {
        //カウントダウン中はストップしてる
        if (script_t1.startflg == false)
        {
            animator.SetFloat("Speed", 0.0f);
        }

        //とりあえず4秒にしてるけど変更するかも
        yield return new WaitForSeconds(2.0f);

        //カウントダウンが0のときに走り出す
        if (script_t1.startflg == true)
        {
            animator.SetFloat("Speed", 1.0f);
        }

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    /*private void Respawn()
    {
        if (GameObject.Find("RespawnCPU2"))
        {
            if (CPU_Script.dead == true)
            {
                time += Time.deltaTime;
                if (time >= 1.0f)
                {
                    time = 0.0f;
                    CPU_Script.agent.enabled = true;
                    Enemy.gameObject.SetActive(true);
                    CPU_Script1.dead = false;
                }
            }
        }
    }*/

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "jump")
        {
            jump = true;
        }
        if (jump == true)
        {
            if (jump_script.Gimmick_Jump == true)
            {
                velocity.y += jumpPower;
            }
        }

        if (other.tag == "judge")
        {
            judge = true;
            //2パターンの処理(0～1)
            int value = 1; //Random.Range(0, 2);
                           //ギミックの通過判定
            switch (value)
            {
                //止める
                case 1:

                    walkSpeed = 0;
                    //2秒後にCall関数を実行する
                    Invoke("Call", 3f);

                    break;
            }
        }

        //ギミックの通過判定
        if (other.tag == "judge2")
        {
            int value1 = Random.Range(0, 2);
            switch (value1)
            {
                //止める
                case 0:

                    walkSpeed = 0;
                    //2秒後にCall関数を実行する
                    Invoke("Call", 3f);

                    break;

                //進行する
                case 1:
                    walkSpeed = 7;

                    break;
            }
        }
        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Dead")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn1", 2f);
        }

        if (other.tag == "Dead_02")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn2", 2f);

        }

        if (other.tag == "Gimmick_Conveyer")
        {
            conflag = true;
            walkSpeed = 9.0f;
        }
        if (other.tag != "Gimmick_Conveyer")
        {
            if (other.tag != "judge")
            {
                conflag = false;
                walkSpeed = 7.0f;
            }
        }

        if(other.tag == "Gimmick_Move")
        {
            walkSpeed = 0;
            move = true;
        }

        if (other.tag != "Gimmick_Move")
        {
            walkSpeed = 7;
            move = false;
        }

        if (other.tag == "Goal")
        {
            goal = true;
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //何秒後かに呼び出すための処理
    void Call()
    {
        judge = false;
        //動き出す
        walkSpeed = 7;
    }

    void CallRespawn1()
    {
        dead = false;
        Enemy.SetActive(true);
        transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }

    void CallRespawn2()
    {
        dead = false;
        Enemy.SetActive(true);
        transform.position = new Vector3(pos2.x, pos2.y, pos2.z);
    }

    //ObjectDistance用の関数
    public void Speed()
    {
        walkSpeed = 11;
    }
}
