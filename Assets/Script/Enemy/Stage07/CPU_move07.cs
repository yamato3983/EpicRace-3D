using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move07 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 7f;
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

    private bool isRespon = false;

    public bool dead;

    //NPCがゴールをしたかどうか
    public bool goal;

    private bool conflag;

    private bool juage;

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

        //pos1 = rp1.transform.position;
        //pos2 = rp2.transform.position;

        juage = false;
        //死亡フラグ
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

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {

        //1番目のギミック
        if (other.tag == "judge")
        {
            walkSpeed = 0;
            //2秒後にCall関数を実行する
            Invoke("Call", 1.5f);

        }

        //2番目のギミック
        if (other.tag == "judge2")
        {
            walkSpeed = 0;
            //2秒後にCall関数を実行する
            Invoke("Call", 1.1f);

        }

        if (other.tag == "judge3")
        {
            //4パターンの処理(0〜4)
            int value = Random.Range(0, 3);
            switch (value)
            {
                //止める
                case 0:

                    walkSpeed = 0;
                    //2秒後にCall関数を実行する
                    Invoke("Call", 1.1f);

                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.2f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }

        if (other.tag == "judge4")
        {
            walkSpeed = 0;
            //2秒後にCall関数を実行する
            Invoke("Call", 1f);
        }
    }

        //int value = 0;//Random.Range(0, 3);

    //何秒後かに呼び出すための処理
    void Call()
    {
        //動き出す
        walkSpeed = 7;
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

    public void Speed()
    {
        walkSpeed = 7;
    }
}
