using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkRun : MonoBehaviour
{

	// Rigidbody
	private Rigidbody rb;

	// ���x
	private float speed = 15.0f;

	//���A������
	public GameObject Shark;

	//�n�_�ƏI�_
	public GameObject StartPoint;
	public GameObject EndPoint;

	// �ړ����x
	[SerializeField] private Vector3 _velocity_x;
	[SerializeField] private Vector3 _velocity_y;
	[SerializeField] private Vector3 _velocity_z;

	//�n�_�ƏI�_�̍��W
	public Vector3 Start_P;
	public Vector3 End_P;



	// ���������\�b�h
	void Start()
	{

		rb = GetComponent<Rigidbody>();

		//���W�擾
		Start_P = StartPoint.transform.position;
		End_P = EndPoint.transform.position;
	}

	void Update()
	{

		Shark.transform.localPosition += _velocity_z * Time.deltaTime;

	}

	public void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Dead")
		{
			Shark.transform.position = new Vector3(Start_P.x, Start_P.y, Start_P.z);

		}

	}

}
