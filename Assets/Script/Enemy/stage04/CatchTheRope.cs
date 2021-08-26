using UnityEngine;
using System.Collections;

public class CatchTheRope : MonoBehaviour
{

	//　キャラクターの到達点
	[SerializeField]
	private Transform arrivalPoint;

	//　到達点を返す
	public Vector3 GetArrivalPoint()
	{
		return arrivalPoint.localPosition;
	}

	void OnTriggerEnter(Collider Rope)
	{
		if (Rope.tag == "Player"
			&& Rope.GetComponent<JumpToRopeChara>() )
		{

			//　キャラクターの親をロープにする
			Rope.transform.SetParent(transform);

			//　キャラクターにCatchTheRopeスクリプトを渡し、状態を変更する
			var jumpToRope = Rope.GetComponent<JumpToRopeChara>();
			jumpToRope.SetState(JumpToRopeChara.State.catchRope, this);

		}
	}

	//　ロープに記憶しておくキャラクターの状態をセット
	//public void SetState(State sta)
	//{
		//state = sta;
	//}
}