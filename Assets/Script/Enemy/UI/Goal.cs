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

    //public Enemymove script_NPC;

    // Start is called before the first frame update
    void Start()
    {
        nav_mesh_agent = GetComponent<NavMeshAgent>();

        nav_mesh_agent.SetDestination(TargetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        //ギミック1回目で落下した時に再度目標地点に向かうようにする
        if(other.tag == "judge")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject.transform.position);
        }

        //ギミック2回目で落下した時に再度目標地点に向かうようにする
        if (other.tag == "judge2")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject.transform.position);
        }

        //目標地点に到達
        if (other.tag == "Goal")
        {
            //ナビゲーションを止める
            NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.isStopped = true;
        }
    }
}
