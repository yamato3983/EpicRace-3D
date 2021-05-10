using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goal : MonoBehaviour
{
    [SerializeField]
    GameObject TargetObject;

    [SerializeField]
    NavMeshAgent nav_mesh_agent;

    // Start is called before the first frame update
    void Start()
    {
        
        nav_mesh_agent = GetComponent<NavMeshAgent>();

        nav_mesh_agent.SetDestination(TargetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //nav_mesh_agent.SetDestination(TargetObject.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //目標地点に到達
        if (other.tag == "Goal")
        {
            //ナビゲーションを止める
            NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.isStopped = true;
        }
    }
}
