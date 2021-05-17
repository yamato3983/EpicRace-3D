using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject GoalLine_PL;	// 移動予定地のオブジェクト
    //public Transform target = GameObject.Find("GoalLine_PL").transform;
    NavMeshAgent agent;
    int flg = 0;

    void Start()
    {
        //Vector3 tmp = GameObject.Find("Player").transform.position;
        //Debug.Log(tmp);
        agent = GetComponent<NavMeshAgent>();
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
