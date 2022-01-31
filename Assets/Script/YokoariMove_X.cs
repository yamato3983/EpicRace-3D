using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_X : MonoBehaviour
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

        if (timeCount >= 0f && timeCount <= 0.6f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 0.9f && timeCount <= 1.5f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 1.5f && timeCount <= 2.1f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }


        if (timeCount >= 2.4f && timeCount <= 3.0f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 3f)
        {
            timeCount = 0;
        }
    }
}
