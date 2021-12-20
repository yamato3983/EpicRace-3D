using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yokoariRun : MonoBehaviour
{
	// Animator コンポーネント
	private Animator animator;

	// 設定したフラグの名前
	private const string key_isRun = "isRun";

	// Rigidbody
	private Rigidbody rb;

	// 速度
	private float speed = 15.0f;

	//横アリくん
	public GameObject Yokoari;

	//始点と終点
	public GameObject StartPoint;
	public GameObject EndPoint;

	//始点と終点の座標
	public Vector3 Start_P;
	public Vector3 End_P;

	

	// 初期化メソッド
	void Start()
	{
		// 自分に設定されているAnimatorコンポーネントを習得する
		this.animator = GetComponent<Animator>();

		rb = GetComponent<Rigidbody>();

		//座標取得
		Start_P = StartPoint.transform.position;
		End_P = EndPoint.transform.position;
	}

	void Update()
	{

		// WaitからRunに遷移する
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
