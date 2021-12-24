using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmmikcGolon : MonoBehaviour
{
	// Animator コンポーネント
	private Animator animator;

	// Rigidbody
	private Rigidbody rb;

	// 速度
	private float speed = 5.0f;

	//横アリくん
	public GameObject Gologolo;

	//始点と終点
	public GameObject StartPoint;
	//public GameObject EndPoint;

	//始点と終点の座標
	public Vector3 Start_P;
	//public Vector3 End_P;



	// 初期化メソッド
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		//座標取得
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
