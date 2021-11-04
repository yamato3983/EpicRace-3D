using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotAngle_Roll_B : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;            //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    [SerializeField]
    public bool gimmickFlag_Roll;

    public enum Gimmick
    {
        MOVE, //稼働
        STOP  //停止中
    }

    Gimmick gimmick = Gimmick.STOP; //最初は停止してる

    private void Start()
    {
        //初期化
        step = 0;
        speed = 240f;

    }

    void Update()
    {
        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        //0～3秒
        if (timeCount >= 0f && timeCount <= 0.8f)
        {

            //ギミックの状態を動いてる状態に
            gimmick = Gimmick.MOVE;

            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(-180, 0, 0), step);
            Debug.Log("1回目");

        }

        //3～6秒
        if (timeCount >= 0.8f && timeCount <= 1.6f)
        {
            Debug.Log("グラグ切り替えの為何もしない");

            //ギミックの状態を止まってる状態に
            gimmick = Gimmick.STOP;

        }

        //6～9秒
        if (timeCount >= 1.6f && timeCount <= 2.4f)
        {

            //ギミックの状態を動いてる状態に
            gimmick = Gimmick.MOVE;

            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, 0), step);
            Debug.Log("2回目");

        }

        //9～12秒
        if (timeCount >= 2.4f && timeCount <= 3.2f)
        {

            Debug.Log("グラグ切り替えの為何もしない");

            //ギミックの状態を止まってる状態に
            gimmick = Gimmick.STOP;

        }

        //12秒
        if (timeCount >= 4.0f)
        {
            //タイマーリセット
            timeCount = 0;
            Debug.Log("タイムリセット");
        }

        switch (gimmick)
        {
            //動いてる状態
            case Gimmick.MOVE:
                gimmickFlag_Roll = false;
                break;
            //止まってる状態
            case Gimmick.STOP:
                gimmickFlag_Roll = true;
                break;
        }

    }

    //ギミックフラグのゲッター
    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }
}