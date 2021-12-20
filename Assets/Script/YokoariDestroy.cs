using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariDestroy : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		// 衝突した相手にPlayerタグが付いているとき
		if (collision.gameObject.tag == "Yokoari")
		{
			// 当たった相手を1秒後に削除
			Destroy(collision.gameObject);
		}
	}
}
