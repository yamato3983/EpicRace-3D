using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;

    // 設定したフラグの名前
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    public GameObject RP;

    GameObject PB_A;
    GameObject PB_B;

    PivotAngle_Bridge_A PB_A_Script; //PivotAngle_Bridge_Aが入る変数
    PivotAngle_Bridge_B PB_B_Script; //PivotAngle_Bridge_Bが入る変数

    [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    public NavMeshAgent agent;
    int flg = 0;      //進むか止まるかのフラグ
    Vector3 tmp;
    public Rigidbody rb;

    public bool Dead = false;

    //[SerializeField] NavMeshAgent nav_mesh_agent;
    //public bool Dead = false;


    void Start()
    {
        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        RP = GameObject.Find("RespawnPoint");
        tmp = RP.transform.position;

        PB_A = GameObject.Find("PivotBridge_A");
        PB_A_Script = PB_A.GetComponent<PivotAngle_Bridge_A>();
        PB_B = GameObject.Find("PivotBridge_B");
        PB_B_Script = PB_B.GetComponent<PivotAngle_Bridge_B>();


        agent = GetComponent<NavMeshAgent>();

        var agentRigidbody = agent.GetComponent<Rigidbody>();
        //RigidodyのKinematicをスタート時はONにする
        agentRigidbody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        bool bridgeAflg = PB_A_Script.gimmickFlag_Bridge;
        bool bridgeBflg = PB_B_Script.gimmickFlag_Bridge;
        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.tag == "Gimmick_Bridge" && bridgeBflg == false)
        {
            Debug.Log("落ちる！！");

            /*
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.GetComponent<NavMeshAgent>().isStopped = true;
            */
            //NavmeshもRigidodyのKinematicもOFF
            agent.enabled = false;
            agentRigidbody.isKinematic = false;
            flg = 0;
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

            //NavmeshとRigidodyのKinematicがON
            agentRigidbody.isKinematic = true;
            agent.enabled = true;
        }
       
        if (other.tag == "Goal")
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.isStopped = true;
            Debug.Log("ゴーーール");
        }
    }

    void Update()
    {
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // WaitからRunに遷移する
            this.animator.SetBool(key_isRun, true);
            flg = 1;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            // RunからWaitに遷移する
            this.animator.SetBool(key_isRun, false);
            flg = 0;
        }

        if (flg == 1)
        {
            agent.GetComponent<NavMeshAgent>().isStopped = false;
            agent.SetDestination(GoalLine_PL.transform.position);
        }
        else if (flg == 0)
        {
            agent.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}