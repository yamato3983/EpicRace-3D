using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmmikcGolon : MonoBehaviour
{
	// Animator �R���|�[�l���g
	private Animator animator;

	// Rigidbody
	private Rigidbody rb;

	// ���x
	private float speed = 5.0f;

	//���A������
	public GameObject Gologolo;

	//�n�_�ƏI�_
	public GameObject StartPoint;
	//public GameObject EndPoint;

	//�n�_�ƏI�_�̍��W
	public Vector3 Start_P;
	//public Vector3 End_P;



	// ���������\�b�h
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		//���W�擾
		Start_P = StartPoint.transform.position;
		//End_P = EndPoint.transform.position;
	}

	void Update()
	{

		Gologolo.transform.position += transform.forward * speed * Time.deltaTime;


	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Dead")
		{
			Gologolo.transform.position = new Vector3(Start_P.x, Start_P.y, Start_P.z);

		}

	}

}
