using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class CPU_move01 : MonoBehaviour
{
	[SerializeField, HideInInspector] public NavMeshAgent agent;
	[SerializeField, HideInInspector] Animator animator;
	[SerializeField] NavMeshAgent nav_mesh_agent;

	//橋関連で必要なもの
	//ギミック1番目の橋用
	GameObject PivotBridge_A;
	GameObject PivotBridge_B;

	//A
	public PivotAngle_Bridge_A script_b1;
	//B
	public PivotAngle_Bridge_B script_b2;

	//ギミック2番目のロール用
	GameObject PivotRoll_A;
	GameObject PivotRoll_B;

	//A
	public PivotAngle_Roll_A script_r1;
	//B
	public PivotAngle_Roll_B script_r2;

	//カウントダウン用
	GameObject GemeObject;
	public Countdown script_t1;

	public GameObject Enemy;

	public GameObject rp1;
	public GameObject rp2;
	public Rigidbody rb;

	Vector3 pos1, pos2;

	public bool dead;
	//NPCがゴールをしたかどうか
	public bool goal;

	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		Enemy = GameObject.Find("Enemy");

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//開始時はNavmeshを切る
		StartCoroutine("Dush");

		//RigidodyのKinematicをスタート時はONにする
		agentRigidbody.isKinematic = true;

		//ギミック橋の左側
		PivotBridge_A = GameObject.Find("PivotBridge_A");

		//ギミック橋の右側
		PivotBridge_B = GameObject.Find("PivotBridge_B");

		//ギミックロールの左側
		PivotRoll_A = GameObject.Find("PivotRoll_A");

		//ギミックロールの右側
		PivotRoll_B = GameObject.Find("PivotRoll_B");

		//リスポーン
		rp1 = GameObject.Find("RespawnCPU");
		rp2 = GameObject.Find("RespawnCPU2");
		pos1 = rp1.transform.position;
		pos2 = rp2.transform.position;

		dead = false;
		goal = false;
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
		if(script_t1.startflg == false)
        {
			nav_mesh_agent.isStopped = true;
		}

		//とりあえず4秒にしてるけど変更するかも
		yield return new WaitForSeconds(3.0f);

		//カウントダウンが0のときに走り出す
		if (script_t1.startflg == true)
		{
			nav_mesh_agent.isStopped = false;
		}
	}

	//タグの判定
	private void OnTriggerEnter(Collider other)
	{
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		//死亡ゾーンに入った時の処理(ギミックの1番目)
		if (other.tag == "Dead")
		{
			
			//dead = true;
			/*this.gameObject.SetActive(false);
			agent.Warp(new Vector3(pos1.x, pos1.y, pos1.z));

			//NavmeshとRigidodyのKinematicがON
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
			nav_mesh_agent.isStopped = false;
			agentRigidbody.isKinematic = true;
			agent.enabled = true;

			dead = true;*/
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

			//2パターンの処理(0～6)
			int value = 4;// Random.Range(0, 6);

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
		if (script_b1.gimmickFlag_Bridge == false && other.tag == "Gimmick_Bridge")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.Warp(new Vector3(pos1.x, pos1.y, pos1.z));
			
			//NavmeshとRigidodyのKinematicがON
			nav_mesh_agent.isStopped = false;
			agent.enabled = true;
			dead = true;

		}

		if (script_b2.gimmickFlag_Bridge == false && other.tag == "Gimmick_Bridge")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.Warp(new Vector3(pos1.x, pos1.y, pos1.z));
			

			//NavmeshとRigidodyのKinematicがON
			//agentRigidbody.isKinematic = true;
			nav_mesh_agent.isStopped = false;
			agent.enabled = true;
			dead = true;
		}

		/********************************************/
		//死亡ゾーンに入った時の処理(ギミック2番目)
		if (other.tag == "Dead_02")
		{
			
		}

		//ギミック2番目通過判定
		if (other.tag == "judge2")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//橋ロールAのスクリプトから参照させる用
			PivotRoll_A = GameObject.Find("PivotRoll_A");
			script_r1 = PivotRoll_A.GetComponent<PivotAngle_Roll_A>();

			//橋ロールBのスクリプトから参照させる用
			PivotRoll_B = GameObject.Find("PivotRoll_B");
			script_r2 = PivotRoll_B.GetComponent<PivotAngle_Roll_B>();

			//2パターンの処理(0～5)
			int value =　Random.Range(0, 6);

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

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.Warp(new Vector3(pos2.x, pos2.y, pos2.z));

			//NavmeshとRigidodyのKinematicがON
			nav_mesh_agent.isStopped = false;
			agent.enabled = true;
			dead = true;
		}

		if (script_r2.gimmickFlag_Roll == false && other.tag == "Gimmick_Roll")
		{
			//NavmeshもRigidodyのKinematicもOFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;

			//ナビゲーション関連の機能
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.Warp(new Vector3(pos2.x, pos2.y, pos2.z));

			//NavmeshとRigidodyのKinematicがON
			nav_mesh_agent.isStopped = false;
			agent.enabled = true;
			dead = true;

		}

		//ゴールしたら
		if(other.tag == "Goal")
        {
			goal = true;
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


