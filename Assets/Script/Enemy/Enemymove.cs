using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class Enemymove : MonoBehaviour
{
	[SerializeField, HideInInspector] NavMeshAgent agent;
	[SerializeField, HideInInspector] Animator animator;
	[SerializeField] GameObject TargetObject;
	[SerializeField] NavMeshAgent nav_mesh_agent;

	Rigidbody rb;

	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		
		rb = GetComponent<Rigidbody>();
		agent.enabled = true;
	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

		agent.nextPosition = transform.position;


		if(agent.enabled == false)
        {
			Debug.Log("������2");
			//transform.position += TargetObject.transform.position;
		}

	}

    //���S����
    private void OnTriggerEnter(Collider other)
	{
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		if (other.tag == "Dead")
		{
			Debug.Log("���S");

			//�i�r�Q�[�V�������~�߂�
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
			nav_mesh_agent.isStopped = true;

			agent.Warp(new Vector3(8.0f, 5.0f, -1.5f));
		}

		//�M�~�b�N�̒ʉߔ���
		if(other.tag == "judge")
        {
			//agent.updatePosition = false;

			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			int value = 0;//Random.Range(0, 1);

            switch (value)
            {
				//�~�߂�
				case 0:
					Debug.Log("�~�߂�");
					//�i�r�Q�[�V�������~�߂�
					nav_mesh_agent.isStopped = false;
					break;

				//�i�s����
				case 1:
					Debug.Log("������1");
					//nav_mesh_agent.isStopped = true;

					agent.enabled = false;
					//agentRigidbody.isKinematic = false;

					//transform.position += TargetObject.transform.position;
					//transform.position = transform.forward * 1 * Time.deltaTime;

					//agent.enabled = true;

					if (other.tag == "judge_f")
					{
					nav_mesh_agent.isStopped = false;
					
					}
					break;
			}
		}
	}
}


