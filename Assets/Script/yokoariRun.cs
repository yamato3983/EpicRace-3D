using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokoariRun : MonoBehaviour
{
	// Animator �R���|�[�l���g
	private Animator animator;

	// �ݒ肵���t���O�̖��O
	private const string key_isRun = "isRun";

	// Rigidbody
	private Rigidbody rb;

	// ���x
	private float speed = 15.0f;

	//���A������
	public GameObject Yokoari;

	//�n�_�ƏI�_
	public GameObject StartPoint;
	public GameObject EndPoint;

	//�n�_�ƏI�_�̍��W
	public Vector3 Start_P;
	public Vector3 End_P;

	

	// ���������\�b�h
	void Start()
	{
		// �����ɐݒ肳��Ă���Animator�R���|�[�l���g���K������
		this.animator = GetComponent<Animator>();

		rb = GetComponent<Rigidbody>();

		//���W�擾
		Start_P = StartPoint.transform.position;
		End_P = EndPoint.transform.position;
	}

	void Update()
	{

		// Wait����Run�ɑJ�ڂ���
		this.animator.SetBool(key_isRun, true);

		Yokoari.transform.position += transform.forward * speed * Time.deltaTime;


	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Dead")
		{
			Yokoari.transform.position = new Vector3(Start_P.x, Start_P.y, Start_P.z);

		}

	}

}
