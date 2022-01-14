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
	private float speed = 10.0f;

	//横アリくん
	public GameObject Gologolo;

	//始点と終点
	public GameObject StartPoint;
	//public GameObject EndPoint;

	//時間カウント
	private float timeCount;

	//始点と終点の座標
	public Vector3 Start_P;
	//public Vector3 End_P;

	// 移動速度
	[SerializeField] private Vector3 _velocity_x;
	[SerializeField] private Vector3 _velocity_y;
	[SerializeField] private Vector3 _velocity_z;



	// 初期化メソッド
	void Start()
	{
		rb = GetComponent<Rigidbody>();

		//座標取得
		Start_P = StartPoint.transform.position;
		//End_P = EndPoint.transform.position;

		timeCount = 0;
	}

	void Update()
	{
		transform.Rotate(new Vector3(0, -1, 0));
		timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算


		if (timeCount >= 0 && timeCount <= 3.3f)
		{
			// 速度_velocityで移動する（ローカル座標）
			transform.localPosition += _velocity_z * Time.deltaTime;
		}

		if (timeCount > 3.3f && timeCount <= 3.55f)
		{
			// 速度_velocityで移動する（ローカル座標）
			transform.localPosition -= _velocity_y * Time.deltaTime;
		}

		if (timeCount > 3.55f && timeCount <= 6.85f)
		{
			// 速度_velocityで移動する（ローカル座標）
			transform.localPosition -= _velocity_z * Time.deltaTime;
		}

		if (timeCount > 6.85f && timeCount <= 7.1f)
		{
			// 速度_velocityで移動する（ローカル座標）
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
