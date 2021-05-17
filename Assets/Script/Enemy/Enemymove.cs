using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class Enemymove : MonoBehaviour
{
	[SerializeField, HideInInspector] NavMeshAgent agent;
	[SerializeField, HideInInspector] Animator animator;
	[SerializeField] NavMeshAgent nav_mesh_agent;

	//橋関連で必要なもの
	//ギミック1番目の橋用
	GameObject PivotBridge_A;
	GameObject PivotBridge_B;

	public PivotAngle_Bridge_A script_b1;
	public PivotAngle_Bridge_B script_b2;

	//ギミック2番目のロール用
	GameObject PivotRoll_A;
	public PivotAngle_Roll_A script_r1;

	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//RigidodyのKinematicをスタート時はONにする
		agentRigidbody.isKinematic = true;

		//ギミック橋の左側
        PivotBridge_A = GameObject.Find("PivotBridge_A");

		//ギミック橋の右側
		PivotBridge_B = GameObject.Find("PivotBridge_B");


		PivotRoll_A = GameObject.Find("PivotRoll_A");
	}

	void Update()
	{
		//アニメーションに設定した二つの値の切り替え
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
	}

    //死亡処理
    private void OnTriggerEnter(Collider other)
	{
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		//死亡ゾーンに入った時の処理(ギミックの1番目)
		if (other.tag == "Dead")
		{
			//リスポーン地点の処理
			agent.Warp(new Vector3(9.0f, 5.0f, -1.5f));

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//NavmeshとRigidodyのKinematicがON
			agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		/*********ギミック1の処理*************/

		//ギミックの通過判定
		if (other.tag == "judge")
        {
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//橋のスクリプトから参照させる用(左)
			PivotBridge_A = GameObject.Find("PivotBridge_A");
			script_b1 = PivotBridge_A.GetComponent<PivotAngle_Bridge_A>();

			//橋のスクリプトから参照させる用(右)
			PivotBridge_B = GameObject.Find("PivotBridge_B");
			script_b2 = PivotBridge_B.GetComponent<PivotAngle_Bridge_B>();

			//2パターンの処理(0と1)
			int value = Random.Range(0, 2);

            switch (value)
            {
				//止める(一時的にNavmeshを止めて数秒後にONにする)
				case 0:
					//ナビゲーションを止める
					nav_mesh_agent.isStopped = true;

					//5秒後にCall関数を実行する
					Invoke("Call", 5f);

			        break;

				//進行する(NavmeshはON状態)
				case 1:
					
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//橋が下がってる状態で橋の上に乗ってる状態の処理
		if (script_b1.gimmickFlag_Bridge == false && other.tag == "Gimmick_Bridge")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}
		/********************************************/
		//死亡ゾーンに入った時の処理(ギミック2番目)
		if (other.tag == "Dead_02")
		{
			//リスポーン地点の処理(ギミック2番目で落下した時）
			agent.Warp(new Vector3(-22.0f, 5.0f, -1.5f));

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//NavmeshとRigidodyのKinematicがON
			agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		if (other.tag == "judge2")
        {
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//橋のスクリプトから参照させる用
			PivotRoll_A = GameObject.Find("PivotRoll_A");
			script_r1 = PivotRoll_A.GetComponent<PivotAngle_Roll_A>();

			//2パターンの処理(0と1)
			int value = Random.Range(0, 2);

			switch (value)
			{
				//止める(一時的にNavmeshを止めて数秒後にONにする)
				case 0:
					
					//ナビゲーションを止める
					nav_mesh_agent.isStopped = true;

					//5秒後にCall関数を実行する
					Invoke("Call", 5f);

					break;

				//進行する(NavmeshはON状態)
				case 1:
					
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//橋が下がってる状態で橋の上に乗ってる状態の処理
		if (script_r1.gimmickFlag_Roll == false && other.tag == "Gimmick_Roll")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}
	}

	//何秒後かに呼び出すための処理
	void Call()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


