using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube_03 : MonoBehaviour
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
        gimmickFlag_Wail = true;
    }

    // Update is called once per frame
    void Update()
    {

        timeCount += Time.deltaTime;   //最後のフレームからの経過時間を加算

        //2秒
        if (timeCount >= 1f && timeCount <= 1.5f)
        {
            //上昇
            MoveUp();
            //フラグの切り替え
            gimmickFlag_Wail = false;

        }
        if (timeCount >= 2f && timeCount <= 2.5f)
        {
            //フラグの切り替え
            //gimmickFlag_Wail = false;
        }

        if (timeCount >= 3f && timeCount <= 3.5f)
        {
            //下降
            MoveDown();


        }


        if (timeCount > 3.5)
        {
            timeCount = 0;
            //フラグの切り替え
            gimmickFlag_Wail = true;
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

    //ギミックフラグのゲッター
    public bool Get_gimmickFlag_Wail()
    {
        return gimmickFlag_Wail;
    }
}
