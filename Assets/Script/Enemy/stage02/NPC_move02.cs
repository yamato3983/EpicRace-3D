using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class NPC_move02 : MonoBehaviour
{
	[SerializeField, HideInInspector] NavMeshAgent agent;
	//GameObject Target;
	[SerializeField, HideInInspector] Animator animator;
	[SerializeField] NavMeshAgent nav_mesh_agent;
	[SerializeField] Rigidbody rb;
	//Vector3 WalkTargetPoint;
	[SerializeField] float Speed;

	private bool conveyer;

	//橋関連で必要なもの
	//ギミック1番目の箱用
	GameObject PivotBox;

	//箱
	public PivotAngle_Box script_b;

	//ギミック2番目のベルトコンベアー用
	GameObject Gimmick_Conveyer;

	//ベルトコンベアー
	public Gimmick_Conveyer script_c;

	GameObject GemeObject;
	public Countdown script_t1;

	
	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//開始時はNavmeshを切る
		StartCoroutine("Dush");

		//RigidodyのKinematicをスタート時はONにする
		//agentRigidbody.isKinematic = true;

		//ギミックコンベアー
		PivotBox = GameObject.Find("PivotBox");

		//ギミックコンベアー
		Gimmick_Conveyer = GameObject.Find("Gimmick_Conveyer");

		conveyer = false;

	}

	void Update()
	{
		//アニメーションに設定した二つの値の切り替え
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

		if (conveyer == true)
		{
			//rb.AddForce(transform.forward * Speed);
		}
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
		//var agentRigidbody = agent.GetComponent<Rigidbody>();

		//死亡ゾーンに入った時の処理(ギミックの1番目)
		if (other.tag == "Dead")
		{
			//リスポーン地点の処理
			agent.Warp(new Vector3(8.0f, 5.0f, -1.5f));

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//NavmeshとRigidodyのKinematicがON
			//agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		/*********ギミック1の処理*************/

		//ギミックの通過判定
		if (other.tag == "judge")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//箱のスクリプトから参照させる用
			PivotBox = GameObject.Find("PivotBox");
			script_b = PivotBox.GetComponent<PivotAngle_Box>();


			//2パターンの処理(0〜6)
			int value = Random.Range(0, 6);

			switch (value)
			{
				//止める(一時的にNavmeshを止めて数秒後にONにする)
				case 0:
				case 1:
				case 2:
				case 3:
					//ナビゲーションを止める
					nav_mesh_agent.isStopped = true;

					//3秒後にCall関数を実行する
					Invoke("Call", 3f);

					break;

				//進行する(NavmeshはON状態)
				case 4:
				case 5:
					//ナビゲーションを止めない
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//橋が下がってる状態で橋の上に乗ってる状態の処理
		if (script_b.gimmickFlag_Box != true && other.tag == "Box")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			//agentRigidbody.isKinematic = false;
		}

		/********************************************/
		//ギミック2番目通過判定
		//橋が下がってる状態で橋の上に乗ってる状態の処理
		if (other.tag == "Conveyer")
		{
			agent = GetComponent<NavMeshAgent>();

			//agent.SetDestination(Target.transform.position);

			conveyer = true;

			Debug.Log("速度低下");
			Debug.Log("速度低下" + Speed);
			agent.speed = 2;

			//NavmeshもRigidodyのKinematicもOFF
			//var agentRigidbody = agent.GetComponent<Rigidbody>();
			//agentRigidbody.isKinematic = true;
			//agent.enabled = false;
		}

		if (other.tag != "Conveyer")
		{
			conveyer = false;
		}
	}

	//何秒後かに呼び出すための処理
	void Call()
	{
		//動き出す
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


