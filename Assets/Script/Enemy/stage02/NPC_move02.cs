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

	private bool conbeyer;

	//���֘A�ŕK�v�Ȃ���
	//�M�~�b�N1�Ԗڂ̔��p
	GameObject PivotBox;

	//��
	public PivotAngle_Box script_b;

	//�M�~�b�N2�Ԗڂ̃x���g�R���x�A�[�p
	GameObject Gimmick_Conveyer;

	//�x���g�R���x�A�[
	public Gimmick_Conveyer script_c;

	GameObject GemeObject;
	public Countdown script_t1;

	
	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//�J�n����Navmesh��؂�
		StartCoroutine("Dush");

		//Rigidody��Kinematic���X�^�[�g����ON�ɂ���
		//agentRigidbody.isKinematic = true;

		//�M�~�b�N�R���x�A�[
		PivotBox = GameObject.Find("PivotBox");

		//�M�~�b�N�R���x�A�[
		Gimmick_Conveyer = GameObject.Find("Gimmick_Conveyer");

		conbeyer = false;

	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

		if (conbeyer == true)
		{
			//rb.AddForce(transform.forward * Speed);
		}
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
		//var agentRigidbody = agent.GetComponent<Rigidbody>();

		//���S�]�[���ɓ��������̏���(�M�~�b�N��1�Ԗ�)
		if (other.tag == "Dead")
		{
			//���X�|�[���n�_�̏���
			agent.Warp(new Vector3(8.0f, 5.0f, -1.5f));

			//�i�r�Q�[�V�����֘A�̋@�\
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//Navmesh��Rigidody��Kinematic��ON
			//agentRigidbody.isKinematic = true;
			agent.enabled = true;
		}

		/*********�M�~�b�N1�̏���*************/

		//�M�~�b�N�̒ʉߔ���
		if (other.tag == "judge")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//���̃X�N���v�g����Q�Ƃ�����p
			PivotBox = GameObject.Find("PivotBox");
			script_b = PivotBox.GetComponent<PivotAngle_Box>();


			//2�p�^�[���̏���(0�`6)
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
					//�i�r�Q�[�V�������~�߂Ȃ�
					nav_mesh_agent.isStopped = false;

					break;
			}
		}

		//�����������Ă��Ԃŋ��̏�ɏ���Ă��Ԃ̏���
		if (script_b.gimmickFlag_Box != true && other.tag == "Box")
		{
			//Navmesh��Rigidody��Kinematic��OFF
			agent.enabled = false;
			//agentRigidbody.isKinematic = false;
		}

		/********************************************/
		//�M�~�b�N2�Ԗڒʉߔ���
		if (other.tag == "judge2")
		{
			NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

			//�����[��A�̃X�N���v�g����Q�Ƃ�����p
			Gimmick_Conveyer = GameObject.Find("Gimmick_Conveyer");
			script_c = Gimmick_Conveyer.GetComponent<Gimmick_Conveyer>();


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
					break;
			}
		}

		//�����������Ă��Ԃŋ��̏�ɏ���Ă��Ԃ̏���
		if (other.tag == "Conveyer")
		{
			agent = GetComponent<NavMeshAgent>();

			//agent.SetDestination(Target.transform.position);

			conbeyer = true;

			Debug.Log("���x�ቺ");
			Debug.Log("���x�ቺ"+ Speed);
			agent.speed = 2;

			//Navmesh��Rigidody��Kinematic��OFF
			//var agentRigidbody = agent.GetComponent<Rigidbody>();
			//agentRigidbody.isKinematic = true;
			//agent.enabled = false;
		}
		else
        {
			conbeyer = false;
			agent.speed = 4;
		}

	}

	//���b�ォ�ɌĂяo�����߂̏���
	void Call()
	{
		//�����o��
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


