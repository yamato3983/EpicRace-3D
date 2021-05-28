using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
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
        speed = 120f;

    }

    void Update()
    {
        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 0f && timeCount <= 1.5f)
        {


            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(180, 0, 0), step);
            Debug.Log("1回目");

            //回転状態
            //gimmickFlag_Roll = false;
            //Debug.Log("回転ギミック" + gimmickFlag_Roll);

            gimmick = Gimmick.MOVE;

        }

        if (timeCount >= 2f && timeCount <= 3.5f)
        {
            Debug.Log("グラグ切り替えの為何もしない");

            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 5f && timeCount <= 6.5f)
        {

            gimmick = Gimmick.MOVE;

            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, 0), step);
            Debug.Log("2回目");

        }

        if (timeCount >= 6.5f && timeCount <= 8f)
        {

            Debug.Log("グラグ切り替えの為何もしない");

            gimmick = Gimmick.STOP;

        }
        if (timeCount >= 9.5f)
        {
            //タイマーリセット
            timeCount = 0;
            Debug.Log("タイムリセット");
        }

        switch (gimmick)
        {
            case Gimmick.MOVE:
                gimmickFlag_Roll = false;
                break;
            case Gimmick.STOP:
                gimmickFlag_Roll = true;
                break;
        }

    }

    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }
}

