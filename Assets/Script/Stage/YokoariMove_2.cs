using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YokoariMove_2 : MonoBehaviour
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

        if (timeCount >= 0f && timeCount <= 0.4f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 0.4f && timeCount <= 0.8f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.8f && timeCount <= 1.2f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }


        if (timeCount >= 1.2f && timeCount <= 1.6f)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount > 1.6f)
        {
            timeCount = 0;
        }
    }
}
