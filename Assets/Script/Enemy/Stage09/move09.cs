using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move09 : MonoBehaviour
{
    //private CharacterController enemyController;
    //private Animator animator;

    public GameObject target;
    public GameObject target2;
    public GameObject target3;
    [SerializeField] float speed;

    //　目的地
    //private Vector3 destination;
    //[SerializeField]
    //private float walkSpeed = 7f;
    //　速度
    private Vector3 velocity;
    //　移動方向
    private Vector3 direction;

    //カウントダウン用
    GameObject GemeObject;
    public Countdown script_t1;

    // 自身のTransform
    [SerializeField] private Transform Boat_CPU;
    //public GameObject Boat_CPU;

    //リスポーン
    //public GameObject rp1;
   // public GameObject rp2;

    //Vector3 pos1, pos2;

    private bool isRespon = false;

    public bool dead;

    //NPCがゴールをしたかどうか
    public bool goal;

    private bool conflag;

    private bool juage;

    private bool juage2;

    // Start is called before the first frame update
    void Start()
    {
        //Vector3 tmp = GameObject.Find("GoalLine_CPU").transform.position;
       // GameObject.Find("GoalLine_CPU").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

       // enemyController = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        //destination = new Vector3(tmp.x, tmp.y, tmp.z);
        //velocity = Vector3.zero;

        //リスポーン
        //rp1 = GameObject.Find("RespawnCPU");
        //rp2 = GameObject.Find("RespawnCPU2");

        //pos1 = rp1.transform.position;
       // pos2 = rp2.transform.position;

        juage = false;
        juage2 = false;
        //死亡フラグ
        dead = false;

        Boat_CPU.Rotate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //自分の位置、ターゲット、速度
        if (juage == false && juage2 == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
        if (juage == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2.transform.position, speed);
        }

        if (juage2 == true && juage == false)
        {
            juage = false;
            Boat_CPU.position = Vector3.MoveTowards(transform.position, target3.transform.position, speed);
        }
        // velocity.y += Physics.gravity.y * Time.deltaTime;
        //enemyController.Move(velocity * Time.deltaTime);

    }

    private IEnumerator Dush()
    {
        //カウントダウン中はストップしてる
        if (script_t1.startflg == false)
        {
            //animator.SetFloat("Speed", 0.0f);
        }

        //とりあえず4秒にしてるけど変更するかも
        yield return new WaitForSeconds(2.0f);

        //カウントダウンが0のときに走り出す
        if (script_t1.startflg == true)
        {
            //animator.SetFloat("Speed", 1.0f);
        }

        //if (walkSpeed == 0)
        //{
            //animator.SetFloat("Speed", 0.0f);
        //}
    }

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {

        //1番目の目的地
        if (other.tag == "judge")
        {
            juage = true;
            Boat_CPU.Rotate(new Vector3(0, 90, 0));
        }

        //2番目の目的地
        if (other.tag == "judge2")
        {
            Boat_CPU.Rotate(new Vector3(0, 270, 0));
            juage2 = true;
            juage = false;
        }



        /*//2番目のギミック
        if (other.tag == "judge2")
        {
            walkSpeed = 0;
            //2秒後にCall関数を実行する
            Invoke("Call", 1.1f);

        }

        if (other.tag == "judge3")
        {
            //4パターンの処理(0～4)
            int value = Random.Range(0, 3);
            switch (value)
            {
                //止める
                case 0:

                    walkSpeed = 0;
                    //2秒後にCall関数を実行する
                    Invoke("Call", 1.0f);

                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.0f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }

        if (other.tag == "judge4")
        {
            int value = Random.Range(0, 3);
            switch (value)
            {
                //止める
                case 0:

                    walkSpeed = 0;
                    //2秒後にCall関数を実行する
                    Invoke("Call", 1.0f);

                    break;

                case 1:

                    walkSpeed = 0;
                    Invoke("Call", 2.0f);

                    break;

                case 2:

                    walkSpeed = 7;
                    break;
            }
        }

        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Yokoari")
        {
            dead = true;
            Enemy.SetActive(false);
            Invoke("CallRespawn1", 0.9f);
        }
        else
        {
            dead = false;
        }

        if (other.tag == "Goal")
        {
            goal = true;
            walkSpeed = 0f;
        }*/
    }


    //何秒後かに呼び出すための処理
    void Call()
    {
        //動き出す
       // walkSpeed = 7;
    }

    void CallRespawn1()
    {
        //Enemy.SetActive(true);
        //transform.position = new Vector3(pos1.x, pos1.y, pos1.z);
    }

    void CallRespawn2()
    {
        //Enemy.SetActive(true);
        //transform.position = new Vector3(pos2.x, pos2.y, pos2.z);
    }

    public void Speed()
    {
       // walkSpeed = 7;
    }
}
