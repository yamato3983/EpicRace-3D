using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariDestroy : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		// �Փ˂��������Player�^�O���t���Ă���Ƃ�
		if (collision.gameObject.tag == "Yokoari")
		{
			// �������������1�b��ɍ폜
			Destroy(collision.gameObject);
		}
	}
}
