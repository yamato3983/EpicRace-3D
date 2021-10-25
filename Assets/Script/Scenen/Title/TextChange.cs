using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
	[SerializeField] private Text a;//テキストをアタッチする

	// Use this for initialization
	void Start()
	{
		a.text = "おはよう\nございます。";//テキストの中身を変更
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}