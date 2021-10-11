using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move1_hard : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 1.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;

    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //リスポーン
    public GameObject rp1;
    public GameObject rp2;

    Vector3 pos1, pos2;


    // オブジェクトが停止するターゲットオブジェクトとの距離を格納する変数
    public float stopDistance;
    // オブジェクトがターゲットに向かって移動を開始する距離を格納する変数
    public float moveDistance;

    // ターゲットオブジェクトの Transformコンポーネントを格納する変数
    public Transform target;


    private bool isRespon = false;

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
        rp1 = GameObject.Find("RespawnCPU");
        rp2 = GameObject.Find("RespawnCPU2");
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;
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

        //地面に落ちた時のフラグ
        dead = false;

        // 変数 targetPos を作成してターゲットオブジェクトの座標を格納
        Vector3 targetPos = target.position;

        float current_speed = animator.GetFloat("Speed");

        // モーション切り替えを10秒で完結させる
        animator.SetFloat("Speed", current_speed + Time.deltaTime * 0.1f);

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
            animator.SetFloat("Speed", 5.5f);
        }

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {
        //ギミックの通過判定
        if (other.tag == "judge")
        {
            //2パターンの処理(0～3)
            int value = Random.Range(0, 4);

            switch (value)
            {
                //止める
                case 0:
                    walkSpeed = 0;
                    //1秒後にCall関数を実行する
                    Invoke("Call", 1f);

                    break;

                //進行しない
                case 1:
                    walkSpeed = 0;
                    //1.5秒後にCall関数を実行する
                    Invoke("Call", 1.5f);
                    break;

                //進行する
                case 2:
               
                    walkSpeed = 6;

                    break;

                //進行する
                case 3:

                    walkSpeed = 7;

                    break;
            }
        }

        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Dead")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn1", 0.5f);
        }

        if (other.tag == "Dead_02")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn2", 0.5f);

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
        //動き出す
        walkSpeed = 5;
    }

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

    //ObjectDistance用の関数
    public void Speed()
    {
        walkSpeed = 9;
    }
}
