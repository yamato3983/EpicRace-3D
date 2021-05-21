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

	//���֘A�ŕK�v�Ȃ���
	//�M�~�b�N1�Ԗڂ̋��p
	GameObject PivotBridge_A;
	GameObject PivotBridge_B;

	//A
	public PivotAngle_Bridge_A script_b1;
	//B
	public PivotAngle_Bridge_B script_b2;

	//�M�~�b�N2�Ԗڂ̃��[���p
	GameObject PivotRoll_A;
	GameObject PivotRoll_B;

	//A
	public PivotAngle_Roll_A script_r1;
	//B
	public PivotAngle_Roll_B script_r2;

	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//Rigidody��Kinematic���X�^�[�g����ON�ɂ���
		agentRigidbody.isKinematic = true;

		//�M�~�b�N���̍���
		PivotBridge_A = GameObject.Find("PivotBridge_A");

		//�M�~�b�N���̉E��
		PivotBridge_B = GameObject.Find("PivotBridge_B");

		//�M�~�b�N���[���̍���
		PivotRoll_A = GameObject.Find("PivotRoll_A");

		//�M�~�b�N���[���̉E��
		PivotRoll_B = GameObject.Find("PivotRoll_B");
	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
	}

	//���S����
	private void OnTriggerEnter(Collider other)
	{
		var agentRigidbody = agent.GetComponent<Rigidbody>();

		//���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
		if (other.tag == "Dead")
		{
			//���X�|�[���n�_�̏���
			agent.Warp(new Vector3(8.0f, 5.0f, -1.5f));

			//�i�r�Q�[�V�����֘A�̋@�\
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//Navmesh��Rigidody��Kinematic��ON
			agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		/*********�M�~�b�N1�̏���*************/

		//�M�~�b�N�̒ʉߔ���
		if (other.tag == "judge")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//���̃X�N���v�g����Q�Ƃ�����p(��)
			PivotBridge_A = GameObject.Find("PivotBridge_A");
			script_b1 = PivotBridge_A.GetComponent<PivotAngle_Bridge_A>();

			//���̃X�N���v�g����Q�Ƃ�����p(�E)
			PivotBridge_B = GameObject.Find("PivotBridge_B");
			script_b2 = PivotBridge_B.GetComponent<PivotAngle_Bridge_B>();

			//2�p�^�[���̏���(0�`6)
			int value = Random.Range(0, 6);

			switch (value)
			{
				//�~�߂�(�ꎞ�I��Navmesh���~�߂Đ��b���ON�ɂ���)
				case 0:
				case 1:
				case 2:
					//�i�r�Q�[�V�������~�߂�
					nav_mesh_agent.isStopped = true;

					//3�b���Call�֐������s����
					Invoke("Call", 3f);

					break;

				//�i�s����(Navmesh��ON���)
				case 3:
				case 4:
				case 5:

					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//�����������Ă��Ԃŋ��̏�ɏ���Ă��Ԃ̏���
		if (script_b1.gimmickFlag_Bridge == false && other.tag == "Gimmick_Bridge")
		{
			//Navmesh��Rigidody��Kinematic��OFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}

		if (script_b2.gimmickFlag_Bridge == false && other.tag == "Gimmick_Bridge")
		{
			//Navmesh��Rigidody��Kinematic��OFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}

		/********************************************/
		//���S�]�[���ɓ��������̏���(�M�~�b�N2�Ԗ�)
		if (other.tag == "Dead_02")
		{
			//���X�|�[���n�_�̏���(�M�~�b�N2�Ԗڂŗ����������j
			agent.Warp(new Vector3(-22f, 5.0f, -1.5f));

			//�i�r�Q�[�V�����֘A�̋@�\
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//Navmesh��Rigidody��Kinematic��ON
			agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		//�M�~�b�N2�Ԗڒʉߔ���
		if (other.tag == "judge2")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//�����[��A�̃X�N���v�g����Q�Ƃ�����p
			PivotRoll_A = GameObject.Find("PivotRoll_A");
			script_r1 = PivotRoll_A.GetComponent<PivotAngle_Roll_A>();

			//�����[��B�̃X�N���v�g����Q�Ƃ�����p
			PivotRoll_B = GameObject.Find("PivotRoll_B");
			script_r2 = PivotRoll_B.GetComponent<PivotAngle_Roll_B>();

			//2�p�^�[���̏���(0�`5)
			int value = 0; Random.Range(0, 6);

			switch (value)
			{
				//�~�߂�(�ꎞ�I��Navmesh���~�߂Đ��b���ON�ɂ���)
				case 0:
				case 1:
				case 2:
					//�i�r�Q�[�V�������~�߂�
					nav_mesh_agent.isStopped = true;

					//5�b���Call�֐������s����
					Invoke("Call", 3f);

					break;

				//�i�s����(Navmesh��ON���)
				case 4:
				case 5:
				case 6:
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//�����������Ă��Ԃŋ��̏�ɏ���Ă��Ԃ̏���
		if (script_r1.gimmickFlag_Roll == false && other.tag == "Gimmick_Roll")
		{
			//Navmesh��Rigidody��Kinematic��OFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}

		if (script_r2.gimmickFlag_Roll == false && other.tag == "Gimmick_Roll")
		{
			//Navmesh��Rigidody��Kinematic��OFF
			agent.enabled = false;
			agentRigidbody.isKinematic = false;
		}
	}

	//���b�ォ�ɌĂяo�����߂̏���
	void Call()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


