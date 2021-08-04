using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_01 : MonoBehaviour
{
    //動く速さ
    private float speed = 3.0f;

    //カウント
    private float timeCount;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算

        //2秒
        if (timeCount >= 2 && timeCount <= 4)
        {
            //上昇
            MoveUp();
        }

        if(timeCount >= 6 && timeCount <=8)
        {
            //下降
            MoveDown();
        }

        if(timeCount > 8.1)
        {
            timeCount = 0;
        }

    }

    void MoveUp()
    {
        //transform取得
        Transform myTrans = this.transform;
        //現在の座標取得
        Vector3 pos = myTrans.position;

        //移動先
        Vector3 direction = new Vector3(pos.x, 7f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

    void MoveDown()
    {
        //transform取得
        Transform myTrans = this.transform;
        //現在の座標取得
        Vector3 pos = myTrans.position;

        //移動先
        Vector3 direction = new Vector3(pos.x, 2.02f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }
}
