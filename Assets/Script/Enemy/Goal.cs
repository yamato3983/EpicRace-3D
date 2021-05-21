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
        //�M�~�b�N1��ڂŗ����������ɍēx�ڕW�n�_�Ɍ������悤�ɂ���
        if(other.tag == "judge")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject.transform.position);
        }

        //�M�~�b�N2��ڂŗ����������ɍēx�ڕW�n�_�Ɍ������悤�ɂ���
        if (other.tag == "judge2")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject.transform.position);
        }

        //�ڕW�n�_�ɓ��B
        if (other.tag == "Goal")
        {
            //�i�r�Q�[�V�������~�߂�
            NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.isStopped = true;
        }
    }
}
