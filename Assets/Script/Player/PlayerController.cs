using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Animator コンポーネント
    private Animator animator;

    // Animatorの設定したフラグの名前
    private const string key_isRun = "isRun";

    private float time = 0.0f;

    public GameObject RP;
    public GameObject RP2;

    GameObject Player;

    //PivotBridgeが入る変数
    GameObject PB_A;
    GameObject PB_B;
    PivotAngle_Bridge_A PB_A_Script; //PivotAngle_Bridge_Aが入る変数
    PivotAngle_Bridge_B PB_B_Script; //PivotAngle_Bridge_Bが入る変数

    //PivotRollが入る変数
    GameObject PR_A;
    GameObject PR_B;
    PivotAngle_Roll_A PR_A_Script;
    PivotAngle_Roll_B PR_B_Script;

    [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    public NavMeshAgent agent;
    int flg = 0;      //進むか止まるかのフラグ
    Vector3 tmp,tmp2;//リスポーンポイントの座標が入る変数
    public Rigidbody rb;

    public bool Dead = false;

    //[SerializeField] NavMeshAgent nav_mesh_agent;
    //public bool Dead = false;


    void Start()
    {
        Player = GameObject.Find("unitychan");

        // 自分に設定されているAnimatorコンポーネントを習得する
        this.animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();

        //リスポーン一ポイントのデータを受け取る
        RP = GameObject.Find("RespawnPoint");
        RP2 = GameObject.Find("RespawnPoint2");
        tmp = RP.transform.position;
        tmp2 = RP2.transform.position;

        //ステージギミックからデータを受け取る
        PB_A = GameObject.Find("PivotBridge_A");
        PB_A_Script = PB_A.GetComponent<PivotAngle_Bridge_A>();
        PB_B = GameObject.Find("PivotBridge_B");
        PB_B_Script = PB_B.GetComponent<PivotAngle_Bridge_B>();

        PR_A = GameObject.Find("PivotRoll_A");
        PR_A_Script = PR_A.GetComponent<PivotAngle_Roll_A>();
        PR_B = GameObject.Find("PivotRoll_B");
        PR_B_Script = PR_B.GetComponent<PivotAngle_Roll_B>();

        agent = GetComponent<NavMeshAgent>();

        var agentRigidbody = agent.GetComponent<Rigidbody>();
        //RigidodyのKinematicをスタート時はONにする
        agentRigidbody.isKinematic = true;
    }

    private void OnTriggerStay(Collider other)
    {
        //橋のギミックのフラグを代入
        bool bridgeAflg = PB_A_Script.gimmickFlag_Bridge;
        bool bridgeBflg = PB_B_Script.gimmickFlag_Bridge;

        //回転ギミックのフラグを代入
        bool rollAflg = PR_A_Script.gimmickFlag_Roll;
        bool rollBflg = PR_B_Script.gimmickFlag_Roll;

        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.tag == "Gimmick_Bridge" && bridgeBflg == false || other.tag == "Gimmick_Roll" && rollBflg == false)
        {
            Debug.Log("落ちる！！");

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

        if (other.gameObject.tag == "Dead_02")
        {
            Debug.Log("死んだ！！(回転");
            this.gameObject.SetActive(false);
            agent.Warp(new Vector3(tmp2.x, tmp2.y, tmp2.z));
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

        if (Player == null)
        {

        }

    }
}