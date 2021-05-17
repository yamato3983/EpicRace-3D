using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject RP;

   [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    NavMeshAgent agent;
    int flg = 0;
    Vector3 tmp;
    Rigidbody rb;

    public bool Dead = false;

    //[SerializeField] NavMeshAgent nav_mesh_agent;
    //public bool Dead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RP = GameObject.Find("RespawnPoint");
        tmp = RP.transform.position;
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var agentRigidbody = agent.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Dead")
        {
            //ナビゲーションを止める
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
           agent.isStopped = true;

            agent.Warp(new Vector3(tmp.x, tmp.y, tmp.z));
        }
        if (other.tag == "Respawn")
        {
            Debug.Log("触れた！！");
            //agent.updatePosition = false;
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
            flg = 1;
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        { flg = 0; }

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
