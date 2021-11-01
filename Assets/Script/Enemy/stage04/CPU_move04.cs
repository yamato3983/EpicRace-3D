using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CPU_move04 : MonoBehaviour
{
    private CharacterController enemyController;
    private Animator animator;

    //　目的地
    private Vector3 destination;
    [SerializeField]
    private float walkSpeed = 7.0f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;

    //壁
    GameObject MoveCube;
    GameObject MoveCube2;
    GameObject MoveCube3;

    public MoveCube_01 cube1;
    public MoveCube_02 cube2;
    public MoveCube_03 cube3;

    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    public GameObject Enemy;

    //リスポーン
    public GameObject rp1;
    public GameObject rp2;
    public GameObject rp3;
    public GameObject rp4;
    //public GameObject rp5;

    Vector3 pos1, pos2, pos3, pos4; //pos5;

    private bool isRespon = false;

    public bool dead;

    //NPCがゴールをしたかどうか
    public bool goal;

    private bool dash;

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
        rp4 = GameObject.Find("RespawnCPU4");
        //rp5 = GameObject.Find("RespawnCPU5");
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;
        pos3 = rp3.transform.position;
        pos4 = rp4.transform.position;
        //pos5 = rp5.transform.position;
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
            animator.SetFloat("Speed", 1.0f);
        }

        if (walkSpeed == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }

    //タグの判定
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "judge")
        {
            if(cube1.gimmickFlag_Wail == false)
            {  
                walkSpeed = 0;
            }
            if (cube1.gimmickFlag_Wail == true)
            {
                walkSpeed = 7.0f;
            }  
        }

        if (other.tag == "judge2")
        {
            if (cube2.gimmickFlag_Wail == false)
            {
                walkSpeed = 0;
            }
            if (cube2.gimmickFlag_Wail == true)
            {
                walkSpeed = 7.0f;
            }
        }

        if (other.tag == "judge3")
        {
            if (cube3.gimmickFlag_Wail == false)
            {
                walkSpeed = 0;
            }
            if (cube3.gimmickFlag_Wail == true)
            {
                walkSpeed = 7.0f;
            }
        }

        if (other.tag == "judgeBrigge")
        {
            //2パターンの処理(0～6)
            int value = Random.Range(0, 6);

            switch (value)
            {
                //止める(一時的にNavmeshを止めて数秒後にONにする)
                case 0:
                case 1:
                case 2:
                case 3:
                    walkSpeed = 0f;

                    //3秒後にCall関数を実行する
                    Invoke("Call", 3f);

                    break;

                //進行する(NavmeshはON状態)
                case 4:
                case 5:
                    walkSpeed = 7.0f;

                    break;
            }
        }

        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Dead")
        {
            dead = true;
            Enemy.SetActive(false);
            //1秒後にCallRespawn1関数を実行する
            Invoke("CallRespawn1", 2f);
        }

        if (other.tag == "Dead_02")
        {
            dead = true;
            Enemy.SetActive(false);
            //1秒後にCallRespawn3関数を実行する
            Invoke("CallRespawn3", 2f);
        }

        if (other.tag == "Dead03")
        {
            dead = true;
            Enemy.SetActive(false);
            //1秒後にCallRespawn3関数を実行する
            Invoke("CallRespawn4", 2f);
        }

        if (other.tag == "Hammer")
        {
            dead = true;
            Enemy.SetActive(false);
            //1秒後にCallRespawn2関数を実行する
            Invoke("CallRespawn2", 2f);

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
        walkSpeed = 7.0f;
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

    void CallRespawn4()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos4.x, pos4.y, pos4.z);
    }

    /*void CallRespawn5()
    {
        Enemy.SetActive(true);
        transform.position = new Vector3(pos5.x, pos5.y, pos5.z);
    }*/
}
