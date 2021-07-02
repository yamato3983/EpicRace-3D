using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickRing : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    public bool gimmickFlag_Ring;   //true:橋が架かってる false:橋が下りてる


    private void Start()
    {
        //初期化
        step = 0;
        speed = 120f;

        //最初は通れる
        gimmickFlag_Ring = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算
        step = speed * Time.deltaTime; //スピードと最終フレームの時間を掛け合わせる
        rot = this.transform.rotation; //現在のRotationを取得

        //0～2秒
        if (timeCount >= 2f && timeCount <= 4f)
        {

            //回転
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);


            //回転中
            gimmickFlag_Ring = false;
        
        }

        //2～3秒
        if(timeCount >= 4 && timeCount <= 6)
        {
            gimmickFlag_Ring = true;
        }

        //3～5秒
        if (timeCount >= 6f && timeCount <= 8f)
        {
            //回転
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);


            //回転してない
            gimmickFlag_Ring = false;
           
        }
        //5～7秒
        if(timeCount >=8f && timeCount <=10f)
        {
            gimmickFlag_Ring = true;
        }

        //7秒
        if (timeCount >= 10f)
        {
            timeCount = 0;
            Debug.Log("タイムリセット");
        }


    }

    //ギミックフラグのゲッター
    public bool Get_gimmickFlag_Box()
    {
        return gimmickFlag_Ring;
    }
}

