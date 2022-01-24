using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkRun : MonoBehaviour
{

	// Rigidbody
	private Rigidbody rb;

	// 速度
	private float speed = 15.0f;

	//横アリくん
	public GameObject Shark;

	//始点と終点
	public GameObject StartPoint;
	public GameObject EndPoint;

	// 移動速度
	[SerializeField] private Vector3 _velocity_x;
	[SerializeField] private Vector3 _velocity_y;
	[SerializeField] private Vector3 _velocity_z;

	//始点と終点の座標
	public Vector3 Start_P;
	public Vector3 End_P;



	// 初期化メソッド
	void Start()
	{

		rb = GetComponent<Rigidbody>();

		//座標取得
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
