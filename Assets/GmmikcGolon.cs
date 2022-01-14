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
	private float speed = 10.0f;

	//���A������
	public GameObject Gologolo;

	//�n�_�ƏI�_
	public GameObject StartPoint;
	//public GameObject EndPoint;

	//���ԃJ�E���g
	private float timeCount;

	//�n�_�ƏI�_�̍��W
	public Vector3 Start_P;
	//public Vector3 End_P;

	// �ړ����x
	[SerializeField] private Vector3 _velocity_x;
	[SerializeField] private Vector3 _velocity_y;
	[SerializeField] private Vector3 _velocity_z;



	// ���������\�b�h
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		//���W�擾
		Start_P = StartPoint.transform.position;
		//End_P = EndPoint.transform.position;

		timeCount = 0;
	}

	void Update()
	{
		transform.Rotate(new Vector3(0, -1, 0));
		timeCount += Time.deltaTime;  //�Ō�̃t���[������̌o�ߎ��Ԃ����Z


		if (timeCount >= 0 && timeCount <= 3.3f)
		{
			// ���x_velocity�ňړ�����i���[�J�����W�j
			transform.localPosition += _velocity_z * Time.deltaTime;
		}

		if (timeCount > 3.3f && timeCount <= 3.55f)
		{
			// ���x_velocity�ňړ�����i���[�J�����W�j
			transform.localPosition -= _velocity_y * Time.deltaTime;
		}

		if (timeCount > 3.55f && timeCount <= 6.85f)
		{
			// ���x_velocity�ňړ�����i���[�J�����W�j
			transform.localPosition -= _velocity_z * Time.deltaTime;
		}

		if (timeCount > 6.85f && timeCount <= 7.1f)
		{
			// ���x_velocity�ňړ�����i���[�J�����W�j
			transform.localPosition += _velocity_y * Time.deltaTime;
		}

		if (timeCount > 7.1f)
		{
			timeCount = 0;
		}


	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Dead")
		{
			Gologolo.transform.position = new Vector3(Start_P.x, Start_P.y, Start_P.z);

		}

	}

}
