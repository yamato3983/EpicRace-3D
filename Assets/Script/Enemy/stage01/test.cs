using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test : MonoBehaviour
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

    private bool isRespon = false;

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
        pos1 = rp1.transform.position;
        pos2 = rp2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyController.isGrounded)
        {
            velocity = Vector3.zero;
            Stop();
            Dush();
            direction = (destination - transform.position).normalized;
            transform.LookAt(new Vector3(destination.x, transform.position.y, destination.z));
            velocity = direction * walkSpeed;
            Debug.Log(destination);
        }
        velocity.y += Physics.gravity.y * Time.deltaTime;
        enemyController.Move(velocity * Time.deltaTime);

        dead = false;
    }

    private void Stop()
    {
        

   
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
            animator.SetFloat("Speed", 5.0f);
        }
    }

    //タグの判定
    private void OnTriggerEnter(Collider other)
    {
        //死亡ゾーンに入った時の処理(ギミックの1番目)
        if (other.tag == "Dead")
        {

            dead = true;
            transform.position = new Vector3(pos1.x, pos1.y, pos1.z);

        }

        if (other.tag == "Dead2")
        {
            dead = true;
            transform.position = new Vector3(pos2.x, pos2.y, pos2.z);

        }

        if (other.tag == "Goal")
        {
            animator.SetFloat("Speed", 0.0f);
        }
    }
}
