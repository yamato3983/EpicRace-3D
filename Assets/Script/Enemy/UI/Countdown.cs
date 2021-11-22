using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
	public Text timerText;
	public Text message;
	public AudioClip sound1;
	AudioSource audioSource;
	private Sprite sprite;
	public Image image;
	public Image image1;
	public Image image2;
	

	public float totalTime;
	int seconds;

	//true:スタート、false:カウントダウン中
	public bool startflg;

	bool sound;

	// Use this for initialization
	void Start()
	{
		//Componentを取得
		audioSource = GetComponent<AudioSource>();
		startflg = false;
		sound = false;
	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		
		seconds = (int)totalTime;
		timerText.text = seconds.ToString();
		

		//2秒以上はスタートフラグはfalseにしてる
		/*if (totalTime == 3)
        {
			sprite = Resources.Load<Sprite>("3");
			image = this.GetComponent<Image>();
			image.sprite = sprite;
			sound = true;
			startflg = false;
		}

		//2秒以上はスタートフラグはfalseにしてる
		if (totalTime == 2)
		{
			sprite = Resources.Load<Sprite>("2");
			image = this.GetComponent<Image>();
			image.sprite = sprite;
			sound = true;
			startflg = false;
		}

		//0のときに画面にGOという文字を出したいため/フラグはtrue
		if (totalTime == 1)
		{
			sprite = Resources.Load<Sprite>("1");
			image = this.GetComponent<Image>();
			image.sprite = sprite;
			timerText.text = "GO";
			startflg = true;
		}*/

		if (totalTime >= 3)
		{
			sound = true;
			startflg = false;
		}
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

		if(sound == true)
        {
			//音(sound1)を鳴らす
			audioSource.PlayOneShot(sound1);
		}
	}
}