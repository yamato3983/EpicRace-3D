using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Move_minus : MonoBehaviour
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

        if (timeCount >= 0 && timeCount <= 0.5)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }
        if (timeCount >= 0.5 && timeCount <= 1)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }

        if (timeCount >= 1 && timeCount <= 1.5)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity * Time.deltaTime;
        }

        if (timeCount >= 1.5 && timeCount <= 2)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity * Time.deltaTime;
        }

        if (timeCount >= 2)
        {
            timeCount = 0;
        }
    }
}
