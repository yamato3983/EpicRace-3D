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
		//アニメーションに設定した二つの値の切り替え
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
	}

	//死亡処理
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Dead")
		{
			Debug.Log("死亡");

			//ナビゲーションを止める
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
			nav_mesh_agent.isStopped = true;

			agent.Warp(new Vector3(8.0f, 3.0f, 0.0f));

		}
	}
}


