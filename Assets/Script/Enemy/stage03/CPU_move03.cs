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
	
	//�J�E���g�_�E���p
	GameObject GemeObject;
	public Countdown script_t1;


	void Start()
	{
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();

		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();

		//�J�n����Navmesh��؂�
		StartCoroutine("Dush");
	}

	void Update()
	{
		//�A�j���[�V�����ɐݒ肵����̒l�̐؂�ւ�
		animator.SetFloat("Speed", agent.velocity.sqrMagnitude);

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

	}
		//���b�ォ�ɌĂяo�����߂̏���
	void Call()
	{
		//�����o��
		NavMeshAgent nav_mesh_agent = GetComponent<NavMeshAgent>();
		nav_mesh_agent.isStopped = false;
	}
}


