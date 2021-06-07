using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Box : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    public bool gimmickFlag_Box;   //true:橋が架かってる false:橋が下りてる


    private void Start()
    {
        //初期化
        step = 0;
        speed = 120f;

        //最初は通れる
        gimmickFlag_Box = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算
        step = speed * Time.deltaTime; //スピードと最終フレームの時間を掛け合わせる
        rot = this.transform.rotation; //現在のRotationを取得

        //0～2秒
        if (timeCount >= 0f && timeCount <= 2f)
        {

            //橋を下す
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(90, 0, 0), step);
            Debug.Log("1回目");

            //橋が下りてる状態
            gimmickFlag_Box = false;
            Debug.Log("落とし穴ギミック:" + gimmickFlag_Box);
        }

        //2～4秒
        if (timeCount >= 2f && timeCount <= 4f)
        {
            //橋を上げる
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2回目");

            //橋が上がってる状態
            gimmickFlag_Box = true;
            Debug.Log("落とし穴ギミック:" + gimmickFlag_Box);
        }

        //秒
        if (timeCount >= 6f)
        {
            timeCount = 0;
            Debug.Log("タイムリセット");
        }


    }

    //ギミックフラグのゲッター
    public bool Get_gimmickFlag_Box()
    {
        return gimmickFlag_Box;
    }
}

