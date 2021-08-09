using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_03 : MonoBehaviour
{

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

        if (timeCount >= 5 && timeCount <= 5.75f)
        {
            //下降
            MoveDown();
        }

        if (timeCount > 6f)
        {
            timeCount = 0;
        }

    }

    void MoveUp()
    {

        //動く速さ
         float speed = 3.0f;

        //transform取得
        Transform myTrans = this.transform;
        //現在の座標取得
        Vector3 pos = myTrans.position;

        //移動先
        Vector3 direction = new Vector3(pos.x, pos.y + 6.35f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

    void MoveDown()
    {

        //動く速さ
        float speed = 8.0f;

        //transform取得
        Transform myTrans = this.transform;
        //現在の座標取得
        Vector3 pos = myTrans.position;

        //移動先
        Vector3 direction = new Vector3(pos.x, pos.y - 6.35f, pos.z);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }
}
