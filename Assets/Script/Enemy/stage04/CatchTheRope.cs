using UnityEngine;
using System.Collections;

public class CatchTheRope : MonoBehaviour
{

	//�@�L�����N�^�[�̓��B�_
	[SerializeField]
	private Transform arrivalPoint;

	//�@���B�_��Ԃ�
	public Vector3 GetArrivalPoint()
	{
		return arrivalPoint.localPosition;
	}

	void OnTriggerEnter(Collider Rope)
	{
		if (Rope.tag == "Player"
			&& Rope.GetComponent<JumpToRopeChara>() )
		{

			//�@�L�����N�^�[�̐e�����[�v�ɂ���
			Rope.transform.SetParent(transform);

			//�@�L�����N�^�[��CatchTheRope�X�N���v�g��n���A��Ԃ�ύX����
			var jumpToRope = Rope.GetComponent<JumpToRopeChara>();
			jumpToRope.SetState(JumpToRopeChara.State.catchRope, this);

		}
	}

	//�@���[�v�ɋL�����Ă����L�����N�^�[�̏�Ԃ��Z�b�g
	//public void SetState(State sta)
	//{
		//state = sta;
	//}
}