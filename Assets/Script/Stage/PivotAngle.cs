using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotAngle : MonoBehaviour
{

    [SerializeField]
    GameObject handle;                //回転させるオブジェクト

    public bool rotflag;       //回転フラグ
    public float speed = 3f;          //回転に掛かる秒数
    public float rotAngle_DOWN = 90f; //回転させたい角度(下げ)
    public float rotAngle_UP = 0f;  //回転させたい角度(上げ)
    public float variation_DOWN;      //1秒間の変化量(下げ)
    public float variation_UP;        //1秒間の変化量(上げ)
    public float rot;                 //角度の総数

    private void Start()
    {
        rotflag = true;
        rot = 12 * Time.deltaTime;
        variation_UP = rotAngle_UP / speed;
    }

    void Update()
    {



        if (rotflag == true)
        {

            iTween.RotateTo(gameObject, iTween.Hash("z", 90f, "delay", 2, "time", 1f));

            //橋が下がったらフラグを切り替える
            if (gameObject.transform.localEulerAngles.z >= 45)
            {
                rotflag = false;
            }
        }

        if (rotflag == false)
        {
            iTween.RotateTo(gameObject, iTween.Hash("z", 0f, "delay", 2, "time", 1f));
        
            //橋が上がったらフラグを切り替える
            if (gameObject.transform.localEulerAngles.z <= 0)
            {
                rotflag = true;
            }
        }

    }
}

