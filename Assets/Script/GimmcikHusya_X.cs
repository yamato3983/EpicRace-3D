using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmcikHusya_X : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    public bool gimmickFlag_Bata;   //true:通れる false:通れない


    private void Start()
    {
        //初期化
        step = 0;
        speed = 180f;

        //最初は通れる
        gimmickFlag_Bata = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算
        step = speed * Time.deltaTime; //スピードと最終フレームの時間を掛け合わせる
        rot = this.transform.rotation; //現在のRotationを取得


        if (timeCount >= 0f && timeCount <= 0.5f)
        {


            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(90, 0, 0), step);
            Debug.Log("1回目");
            gimmickFlag_Bata = false;


        }

        if (timeCount >= 0.5f && timeCount <= 1.0f)
        {
            gimmickFlag_Bata = true;
        }


        if (timeCount >= 1.0f && timeCount <= 1.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(180, 0, 0f), step);
            Debug.Log("2回目");
            gimmickFlag_Bata = false;


        }

        if (timeCount >= 1.5f && timeCount <= 2.0f)
        {
            gimmickFlag_Bata = true;
        }

        if (timeCount >= 2.0f && timeCount <= 2.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90, 0, 0f), step);
            Debug.Log("2回目");
            gimmickFlag_Bata = false;


        }
        if (timeCount >= 2.5f && timeCount <= 3.0f)
        {
            gimmickFlag_Bata = true;
        }

        if (timeCount >= 3.0f && timeCount <= 3.5f)
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2回目");
            gimmickFlag_Bata = false;


        }

        //秒
        if (timeCount >= 4.0f)
        {
            timeCount = 0;
            Debug.Log("タイムリセット");
            gimmickFlag_Bata = true;
            ;
        }
    }

    //ギミックフラグのゲッター
    public bool Get_gimmickFlag_Bata()
    {
        return gimmickFlag_Bata;
    }
}


