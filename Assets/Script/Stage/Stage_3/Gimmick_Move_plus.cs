using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Move_plus: MonoBehaviour
{

    // 移動速度
    [SerializeField] private Vector3 _velocity;

    //時間カウント
    private float timeCount;
    
    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= 0 && timeCount <= 1.0)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.5 && timeCount <= 0.8)
        {
            // 速度_velocityで移動する（ローカル座標）
            //transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.8 && timeCount <= 1.8)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if(timeCount >= 1.8 && timeCount <= 2.1)
        {
            // 速度_velocityで移動する（ローカル座標）
            //transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 1.8 && timeCount <= 2.1)
        {
            // 速度_velocityで移動する（ローカル座標）
            //transform.localPosition += _velocity * Time.deltaTime;
        }

        if(timeCount >= 2.1)
        {
            timeCount = 0;
        }
    }
}


