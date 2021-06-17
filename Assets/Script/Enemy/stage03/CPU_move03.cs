using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class CPU_move03 : MonoBehaviour
{
	[SerializeField, HideInInspector] NavMeshAgent agent;
	[SerializeField, HideInInspector] Animator animator;
	[SerializeField] NavMeshAgent nav_mesh_agent;
	
	//カウントダウン用
	GameObject GemeObject;
	public Countdown script_t1;


	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//開始時はNavmeshを切る
		StartCoroutine("Dush");
	}

	void Update()
	{
		//アニメーションに設定した二つの値の切り替え
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

	}

	//コルーチンでスタート時の挙動を処理してる
	private IEnumerator Dush()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		//カウントダウン中はストップしてる
		if (script_t1.startflg == false)
		{
			nav_mesh_agent.isStopped = true;
		}

		//とりあえず4秒にしてるけど変更するかも
		yield return new WaitForSeconds(4.0f);

		//カウントダウンが0のときに走り出す
		if (script_t1.startflg == true)
		{
			nav_mesh_agent.isStopped = false;
		}
	}

	//タグの判定
	private void OnTriggerEnter(Collider other)
	{


		//死亡ゾーンに入った時の処理(ギミックの1番目)
		if (other.tag == "Dead")
		{
			//リスポーン地点の処理
			agent.Warp(new Vector3(-8.5f, 5f, 16.5f));

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.enabled = true;
		}

		/*********ギミック1の処理*************/

		//ギミックの通過判定
		if (other.tag == "judge")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//2パターンの処理(0～6)
			int value = Random.Range(0, 3);

			switch (value)
			{
				//止める(一時的にNavmeshを止めて数秒後にONにする)
				case 0:
					//ナビゲーションを止める
					nav_mesh_agent.isStopped = true;

					//3秒後にCall関数を実行する
					Invoke("Call", 3f);

					break;

				//進行する(NavmeshはON状態)
				case 1:
				case 2:
					//ナビゲーションを止めない
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		/********************************************/
		//ギミック2番目通過判定

	}
		//何秒後かに呼び出すための処理
	void Call()
	{
		//動き出す
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


