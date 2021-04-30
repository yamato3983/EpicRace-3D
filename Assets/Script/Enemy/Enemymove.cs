using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class Enemymove : MonoBehaviour
{
	[SerializeField, HideInInspector] NavMeshAgent agent;
	[SerializeField, HideInInspector] Animator animator;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
	}

	//���S����
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Dead")
		{
			Debug.Log("���S");

			//�i�r�Q�[�V�������~�߂�
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
			nav_mesh_agent.isStopped = true;

			agent.Warp(new Vector3(8.0f, 3.0f, 0.0f));

		}
	}
}


