using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickStels : MonoBehaviour
{

    //時間カウント
    private float timeCount;

    //ギミックのフラグ
    public bool StelsFlag;

    public GameObject Stels01;
    public GameObject Stels02;
    public GameObject Stels03;
    public GameObject Stels04;
    public GameObject Stels05;
    public GameObject Stels06;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        StelsFlag = true; //true:ある false:なし
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        // transformを取得
        Transform myTransform = this.transform;
        // ローカル座標での座標を取得
        Vector3 localPos = myTransform.localPosition;

        if (timeCount >= 0 && timeCount <= 1.0f)
        {
            Stels01.SetActive(false);
            Stels02.SetActive(false);
            Stels03.SetActive(false);
            Stels04.SetActive(false);
            Stels05.SetActive(false);
            Stels06.SetActive(false);

            StelsFlag = false; //消える
        }
        if (timeCount >= 1.0f && timeCount <= 2.0f)
        {
            Stels01.SetActive(true);
            Stels02.SetActive(true);
            Stels03.SetActive(true);
            Stels04.SetActive(true);
            Stels05.SetActive(true);
            Stels06.SetActive(true);

            StelsFlag = true; //ある

        }
        if(timeCount >= 2.0f)
        {
            timeCount = 0;
        }
    }
}
