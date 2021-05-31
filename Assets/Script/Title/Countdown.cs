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

	//true:スタート、false:カウントダウン中
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

		//2秒以上はスタートフラグはfalseにしてる
		if(totalTime > 1)
        {
			startflg = false;
		}
		//0のときに画面にGOという文字を出したいため/フラグはtrue
		if (totalTime <= 1)
		{
			timerText.text = "GO";
			startflg = true;
		}

		//GOの文字が出た後にtextの文字を消す
		if (totalTime <= 0)
		{
			totalTime = 0;
			timerText.text = "";
		}

	}
}