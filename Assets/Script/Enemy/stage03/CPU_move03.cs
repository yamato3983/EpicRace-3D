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
	[SerializeField]
	private Transform[] m_targets = null;
	[SerializeField]
	private float m_destinationThreshold = 0.0f;
	[SerializeField]
	private Transform jumpPoint = null;

	[SerializeField]
	private Transform j_target = null;

	[SerializeField]
	private GameObject cpuObject = null;

	[SerializeField]
	public Rigidbody rb;

	[SerializeField]
	private float m_jumpTime = 0.0f;

	//ジャンプ台用のスクリプト
	GameObject JumpPad;
	public JumpPad jump_script;

	public bool j_flg;

	public float upForce = 20f; //上方向にかける力

	//カウントダウン用
	GameObject GemeObject;
	public Countdown script_t1;

	
	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		//m_navAgent.destination = CurretTargetPosition;


		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//開始時はNavmeshを切る
		StartCoroutine("Dush");

		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;

		j_flg = false;
	}

	void Update()
	{
		//アニメーションに設定した二つの値の切り替え
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

			//rb.AddForce(transform.up * 10.0f, ForceMode.Impulse);
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
		if (other.tag == "judge2")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//ジャンプ台のスクリプトから参照させる用
			JumpPad = GameObject.Find("JumpPad");
			jump_script = JumpPad.GetComponent<JumpPad>();

			//2パターンの処理(0～5)
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
					nav_mesh_agent.isStopped = false;
					rb = GetComponent<Rigidbody>();
					break;
			}
		}

		//着地
		if(other.tag == "Landing")
        {
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
			nav_mesh_agent.isStopped = false;
			//Debug.Log("la"+ nav_mesh_agent.isStopped);
			rb.isKinematic = true;
			//agent.enabled = false;
			nav_mesh_agent.CompleteOffMeshLink();
		}
	}

	//タグがすり抜けたらジャンプ
	private void OnTriggerStay(Collider other)
    {
		if (other.tag == "jump")
		{
			if (jump_script.Gimmick_Jump == true)
			{
				NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
				nav_mesh_agent.autoTraverseOffMeshLink = true;
				nav_mesh_agent.isStopped = true;

				Debug.Log("ジャンプ");

				rb.isKinematic = false;

				Jump(j_target.position);
				j_flg = true;
			}
		}
	}

	//何秒後かに呼び出すための処理
	private void Call()
	{
		//動き出す
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;

		rb = GetComponent<Rigidbody>();
	}


	//ジャンプするための処理
	private void Jump(Vector3 i_targetPos)
	{
		// とりあえず適当に60度でかっ飛ばすとするよ！
		JumpFixedTime(i_targetPos, 10.0f);
	}
	private void JumpFixedTime(Vector3 i_targetPosition, float i_time)
	{
		float speedVec = ComputeVectorFromTime(i_targetPosition, i_time);
		float angle = ComputeAngleFromTime(i_targetPosition, i_time);

		if (speedVec <= 0.0f)
		{
			// その位置に着地させることは不可能のようだ！
			Debug.LogWarning("!!");
			return;
		}

		Vector3 vec = ConvertVectorToVector3(speedVec, angle, i_targetPosition);
		InstantiateShootObject(vec);
	}

	private Vector3 ConvertVectorToVector3(float i_v0, float i_angle, Vector3 i_targetPosition)
	{
		Vector3 startPos = jumpPoint.transform.position;
		Vector3 targetPos = i_targetPosition;
		startPos.y = 0.0f;
		targetPos.y = 0.0f;

		Vector3 dir = (targetPos - startPos).normalized;
		Quaternion yawRot = Quaternion.FromToRotation(Vector3.right, dir);
		Vector3 vec = i_v0 * Vector3.right;

		vec = yawRot * Quaternion.AngleAxis(i_angle, Vector3.forward) * vec;

		return vec;
	}

	private float ComputeVectorFromTime(Vector3 i_targetPosition, float i_angle)
	{
		// xz平面の距離を計算。
		Vector2 startPos = new Vector2(jumpPoint.transform.position.x, jumpPoint.transform.position.z);
		Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		float g = Physics.gravity.y;
		float y0 = jumpPoint.transform.position.y;
		float y = i_targetPosition.y;

		// Mathf.Cos()、Mathf.Tan()に渡す値の単位はラジアンだ。角度のまま渡してはいけないぞ！
		float rad = i_angle * Mathf.Deg2Rad;

		float cos = Mathf.Cos(rad);
		float tan = Mathf.Tan(rad);

		float v0Square = g * x * x / (2 * cos * cos * (y - y0 - x * tan));

		// 負数を平方根計算すると虚数になってしまう。
		// 虚数はfloatでは表現できない。
		// こういう場合はこれ以上の計算は打ち切ろう。
		if (v0Square <= 0.0f)
		{
			return 0.0f;
		}

		float v0 = Mathf.Sqrt(v0Square);
		return v0;
	}

	private float ComputeAngleFromTime(Vector3 i_targetPosition, float i_time)
	{
		Vector2 vec = ComputeVectorXYFromTime(i_targetPosition, i_time);

		float v_x = vec.x;
		float v_y = vec.y;

		float rad = Mathf.Atan2(v_y, v_x);
		float angle = rad * Mathf.Rad2Deg;

		return angle;
	}

	private Vector2 ComputeVectorXYFromTime(Vector3 i_targetPosition, float i_time)
	{
		// 瞬間移動はちょっと……。
		if (i_time <= 0.0f)
		{
			return Vector2.zero;
		}


		// xz平面の距離を計算。
		Vector2 startPos = new Vector2(transform.position.x, transform.position.z);
		Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		// な、なぜ重力を反転せねばならないのだ...
		float g = -Physics.gravity.y;
		float y0 = transform.position.y;
		float y = i_targetPosition.y;
		float t = i_time;

		float v_x = x / t;
		float v_y = (y - y0) / t + (g * t) / 2;

		return new Vector2(v_x, v_y);
	}

	private void InstantiateShootObject(Vector3 i_shootVector)
	{
		//ジャンプする力
		Vector3 force = new Vector3(0.0f, 0.56f, 0.18f);  

		rb.AddForce(force, ForceMode.Impulse);
	}
}


