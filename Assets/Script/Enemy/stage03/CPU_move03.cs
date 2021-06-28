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

	//�W�����v��p�̃X�N���v�g
	GameObject JumpPad;
	public JumpPad jump_script;

	public bool j_flg;

	public float upForce = 20f; //������ɂ������

	//�J�E���g�_�E���p
	GameObject GemeObject;
	public Countdown script_t1;

	
	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		//m_navAgent.destination = CurretTargetPosition;


		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//�J�n����Navmesh��؂�
		StartCoroutine("Dush");

		rb = GetComponent<Rigidbody>();
		rb.isKinematic = true;

		j_flg = false;
	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

			//rb.AddForce(transform.up * 10.0f, ForceMode.Impulse);
	}

	//�R���[�`���ŃX�^�[�g���̋������������Ă�
	private IEnumerator Dush()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		//�J�E���g�_�E�����̓X�g�b�v���Ă�
		if (script_t1.startflg == false)
		{
			nav_mesh_agent.isStopped = true;
		}

		//�Ƃ肠����4�b�ɂ��Ă邯�ǕύX���邩��
		yield return new WaitForSeconds(4.0f);

		//�J�E���g�_�E����0�̂Ƃ��ɑ���o��
		if (script_t1.startflg == true)
		{
			nav_mesh_agent.isStopped = false;
		}
	}

	//�^�O�̔���
	private void OnTriggerEnter(Collider other)
	{
		//���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
		if (other.tag == "Dead")
		{
			//���X�|�[���n�_�̏���
			agent.Warp(new Vector3(-8.5f, 5f, 16.5f));

			//�i�r�Q�[�V�����֘A�̋@�\
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			agent.enabled = true;
		}

		/*********�M�~�b�N1�̏���*************/

		//�M�~�b�N�̒ʉߔ���
		if (other.tag == "judge")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//2�p�^�[���̏���(0�`6)
			int value = Random.Range(0, 3);

			switch (value)
			{
				//�~�߂�(�ꎞ�I��Navmesh���~�߂Đ��b���ON�ɂ���)
				case 0:
					//�i�r�Q�[�V�������~�߂�
					nav_mesh_agent.isStopped = true;

					//3�b���Call�֐������s����
					Invoke("Call", 3f);

					break;

				//�i�s����(Navmesh��ON���)
				case 1:
				case 2:
					//�i�r�Q�[�V�������~�߂Ȃ�
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		/********************************************/
		//�M�~�b�N2�Ԗڒʉߔ���
		if (other.tag == "judge2")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//�W�����v��̃X�N���v�g����Q�Ƃ�����p
			JumpPad = GameObject.Find("JumpPad");
			jump_script = JumpPad.GetComponent<JumpPad>();

			//2�p�^�[���̏���(0�`5)
			int value = Random.Range(0, 6);

			switch (value)
			{
				//�~�߂�(�ꎞ�I��Navmesh���~�߂Đ��b���ON�ɂ���)
				case 0:
				case 1:
				case 2:
				case 3:
					//�i�r�Q�[�V�������~�߂�
					nav_mesh_agent.isStopped = true;

					//3�b���Call�֐������s����
					Invoke("Call", 3f);

					break;

				//�i�s����(Navmesh��ON���)
				case 4:
				case 5:
					nav_mesh_agent.isStopped = false;
					rb = GetComponent<Rigidbody>();
					break;
			}
		}

		//���n
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

	//�^�O�����蔲������W�����v
	private void OnTriggerStay(Collider other)
    {
		if (other.tag == "jump")
		{
			if (jump_script.Gimmick_Jump == true)
			{
				NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
				nav_mesh_agent.autoTraverseOffMeshLink = true;
				nav_mesh_agent.isStopped = true;

				Debug.Log("�W�����v");

				rb.isKinematic = false;

				Jump(j_target.position);
				j_flg = true;
			}
		}
	}

	//���b�ォ�ɌĂяo�����߂̏���
	private void Call()
	{
		//�����o��
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;

		rb = GetComponent<Rigidbody>();
	}


	//�W�����v���邽�߂̏���
	private void Jump(Vector3 i_targetPos)
	{
		// �Ƃ肠�����K����60�x�ł�����΂��Ƃ����I
		JumpFixedTime(i_targetPos, 10.0f);
	}
	private void JumpFixedTime(Vector3 i_targetPosition, float i_time)
	{
		float speedVec = ComputeVectorFromTime(i_targetPosition, i_time);
		float angle = ComputeAngleFromTime(i_targetPosition, i_time);

		if (speedVec <= 0.0f)
		{
			// ���̈ʒu�ɒ��n�����邱�Ƃ͕s�\�̂悤���I
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
		// xz���ʂ̋������v�Z�B
		Vector2 startPos = new Vector2(jumpPoint.transform.position.x, jumpPoint.transform.position.z);
		Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		float g = Physics.gravity.y;
		float y0 = jumpPoint.transform.position.y;
		float y = i_targetPosition.y;

		// Mathf.Cos()�AMathf.Tan()�ɓn���l�̒P�ʂ̓��W�A�����B�p�x�̂܂ܓn���Ă͂����Ȃ����I
		float rad = i_angle * Mathf.Deg2Rad;

		float cos = Mathf.Cos(rad);
		float tan = Mathf.Tan(rad);

		float v0Square = g * x * x / (2 * cos * cos * (y - y0 - x * tan));

		// �����𕽕����v�Z����Ƌ����ɂȂ��Ă��܂��B
		// ������float�ł͕\���ł��Ȃ��B
		// ���������ꍇ�͂���ȏ�̌v�Z�͑ł��؂낤�B
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
		// �u�Ԉړ��͂�����Ɓc�c�B
		if (i_time <= 0.0f)
		{
			return Vector2.zero;
		}


		// xz���ʂ̋������v�Z�B
		Vector2 startPos = new Vector2(transform.position.x, transform.position.z);
		Vector2 targetPos = new Vector2(i_targetPosition.x, i_targetPosition.z);
		float distance = Vector2.Distance(targetPos, startPos);

		float x = distance;
		// �ȁA�Ȃ��d�͂𔽓]���˂΂Ȃ�Ȃ��̂�...
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
		//�W�����v�����
		Vector3 force = new Vector3(0.0f, 0.56f, 0.18f);  

		rb.AddForce(force, ForceMode.Impulse);
	}
}


