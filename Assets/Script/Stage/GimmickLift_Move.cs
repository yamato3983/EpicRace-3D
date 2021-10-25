using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickLift_Move : MonoBehaviour
{
    // 移動速度
    [SerializeField] private Vector3 _velocity_x;
    [SerializeField] private Vector3 _velocity_y;
    [SerializeField] private Vector3 _velocity_z;

    //時間カウント
    private float timeCount;

    private void Start()
    {
        timeCount = 0;
    }

    void Update()
    {

        timeCount += Time.deltaTime;  //最後のフレームからの経過時間を加算

        if (timeCount >= 0 && timeCount <= 0.2)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 0.2 && timeCount <=0.4)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_x * Time.deltaTime;
        }

        if (timeCount >= 0.6 && timeCount <= 0.8)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition -= _velocity_y * Time.deltaTime;
        }

        if (timeCount >= 1.0 && timeCount <= 1.2)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 1.2 && timeCount <= 1.4)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_x * Time.deltaTime;
        }
        if (timeCount >= 1.6 && timeCount <= 1.8)
        {
            // 速度_velocityで移動する（ローカル座標）
            transform.localPosition += _velocity_y * Time.deltaTime;
        }

        if (timeCount >= 2f)
        {
            timeCount = 0;
        }
    }
}
