using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
	public Text timerText;
	public Text message;

	public float totalTime;
	int seconds;

	//true:�X�^�[�g�Afalse:�J�E���g�_�E����
	public bool startflg;

	// Use this for initialization
	void Start()
	{
		startflg = false;
	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		
		seconds = (int)totalTime;
		timerText.text = seconds.ToString();

		//2�b�ȏ�̓X�^�[�g�t���O��false�ɂ��Ă�
		if(totalTime > 1)
        {
			startflg = false;
		}
		//0�̂Ƃ��ɉ�ʂ�GO�Ƃ����������o����������/�t���O��true
		if (totalTime <= 1)
		{
			timerText.text = "GO";
			startflg = true;
		}

		//GO�̕������o�����text�̕���������
		if (totalTime <= 0)
		{
			totalTime = 0;
			timerText.text = "";
		}

	}
}