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

    public bool gimmickFlag_Roll; //回転ギミックフラグ

    /**********************************************
     Subjectというクラスに実装されている機能として
     処理を登録(購読)するSubscribeと処理を実行するOnNextというメソッドがある

     Subscribe:メッセージの受け取り時に実行する関数を登録
     OnNext:Subscribeで登録された関数にメッセージを渡して実行する
     **********************************************/

    /*引数にstringが渡せるSubjectを定義(intやbool等の型も可能)
    Subject<string> sub_string = new Subject<string>();

    //引数にboolが渡せるSubjectを定義
    Subject<bool> sub_bool = new Subject<bool>();

    /*Subjectのうち、IObsevableだけを公開して、処理を登録出来るようにする
    public IObserver<string> Observer
    {
        get { return _subject; }
    }
    */

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

        if (timeCount >= 0f && timeCount <= 2)
        {

            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(-180, 0, 0), step);
            Debug.Log("1回目");

            //回転状態
            gimmickFlag_Roll = false;
            Debug.Log("回転ギミック" + gimmickFlag_Roll);
        }

        if (timeCount >= 3f && timeCount <= 5f)
        {
            Debug.Log("グラグ切り替えの為何もしない");

            //回転状態
            gimmickFlag_Roll = true;
            Debug.Log("回転ギミック" + gimmickFlag_Roll);

        }
        if (timeCount >= 6f && timeCount <= 8f)
        {
            //指定した方向にゆっくり回転する場合
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2回目");

            //回転停止
            gimmickFlag_Roll = false;
            Debug.Log("回転ギミック" + gimmickFlag_Roll);

        }

        if (timeCount >= 10f)
        {
            timeCount = 0;
            Debug.Log("タイムリセット");
        }

    }
    public bool Gimmick_Flag_Roll()
    {
        return gimmickFlag_Roll;
    }

}

