using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    int flg = 0;   

    void Start()
    {
        Vector3 tmp = GameObject.Find("Player").transform.position;
        Debug.Log(tmp);
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
            agent.SetDestination(target.position);
        }
        else if (flg == 0)
        {
            agent.GetComponent<NavMeshAgent>().isStopped = true;
        }
    }
}
