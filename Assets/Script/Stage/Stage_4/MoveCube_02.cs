using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_02 : MonoBehaviour
{
    //動く速さ
    private float speed = 10.0f;

    //カウント
    private float timeCount;

    [SerializeField]
    public bool gimmickFlag_Wail;   //true:橋が架かってる false:橋が下りてる

    // Use this for initialization
    void Start()
    {
        gimmickFlag_Wail = false;
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算

        //2秒
        if (timeCount >= 1 && timeCount <= 1.5)
        {
            //下降
            MoveDown();
        }
        if(timeCount >= 1.5 && timeCount <= 1.6)
        {
            //フラグの切り替え
            gimmickFlag_Wail = true;
        }

        if (timeCount >= 2.5 && timeCount <= 3)
        {
            //上昇
            MoveUp();
            //フラグの切り替え
            gimmickFlag_Wail = false;
        }

        if (timeCount > 3)
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

