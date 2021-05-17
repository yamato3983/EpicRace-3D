using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PivotAngle_Bridge_A : MonoBehaviour
{

    [SerializeField]
    private float angle;

    [SerializeField]
    private float step;           //何度ずつ動かすか

    private Vector3 pos;          //座標
    private Quaternion rot;       //角度

    private float speed;
    private float timeCount; //時間カウント

    public bool gimmickFlag_Bridge;   //true:橋が架かってる false:橋が下りてる

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

        //最初は橋が架かってる
        gimmickFlag_Bridge = true;
    }

    void Update()
    {
        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        step = speed * Time.deltaTime;
        rot = this.transform.rotation;

        if (timeCount >= 2f && timeCount <= 4)
        {

            //橋を下す
            transform.rotation = Quaternion.RotateTowards(rot, Quaternion.Euler(0, 0, -90f), step);
            Debug.Log("1回目");

            //橋が下りてる状態
            gimmickFlag_Bridge = false;
            Debug.Log("橋ギミック:" + gimmickFlag_Bridge);
        }

        if (timeCount >= 5f && timeCount <= 8)
        {
            //橋を上げる
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0f), step);
            Debug.Log("2回目");

            //橋が上がってる状態
            gimmickFlag_Bridge = true;
            Debug.Log("橋ギミック:" + gimmickFlag_Bridge);
        }

        if (timeCount >= 8f)
        {
            timeCount = 0;
            Debug.Log("タイムリセット");
        }


    }

    //ギミックフラグのゲッター
    public bool Get_gimmickFlag_Bridge()
    {
        return gimmickFlag_Bridge;
    }
}


