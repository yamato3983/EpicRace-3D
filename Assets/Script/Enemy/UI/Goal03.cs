using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Goal03 : MonoBehaviour
{
    [SerializeField]
    GameObject TargetObject;

    [SerializeField]
    GameObject TargetObject1;

    [SerializeField]
    GameObject TargetObject2;

    [SerializeField]
    GameObject TargetObject3;

    [SerializeField]
    GameObject TargetObject4;

    //[SerializeField]
    //GameObject TargetObject5;

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
        if (other.tag == "judge")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject2.transform.position);
        }

        //�M�~�b�N2��ڂŗ����������ɍēx�ڕW�n�_�Ɍ������悤�ɂ���
        if (other.tag == "judge2")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.SetDestination(TargetObject4.transform.position);
        }

       if(other.tag == "Intermediate")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();

            nav_mesh_agent.SetDestination(TargetObject1.transform.position);
        }

        if (other.tag == "Intermediate02")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();

            nav_mesh_agent.SetDestination(TargetObject2.transform.position);
        }

        if (other.tag == "Intermediate03")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();

            nav_mesh_agent.SetDestination(TargetObject3.transform.position);
        }

        if (other.tag == "Intermediate04")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();

            nav_mesh_agent.SetDestination(TargetObject4.transform.position);
        }

        /*if (other.tag == "Intermediate05")
        {
            nav_mesh_agent = GetComponent<NavMeshAgent>();

            nav_mesh_agent.SetDestination(TargetObject5.transform.position);
        }*/

        //�ڕW�n�_�ɓ��B
        if (other.tag == "Goal")
        {
            //�i�r�Q�[�V�������~�߂�
            NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
            nav_mesh_agent.isStopped = true;
        }
    }
}
